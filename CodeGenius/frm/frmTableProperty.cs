using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CodeGenius.Entity;
using System.Data.SqlClient;
using CodeGenius.Frame.TreeNodeBase;

namespace CodeGenius
{
    /***************************************
     * * 创建人： 刘祥松
     * * 创建时间：2015/06/09
     * * 描述：查看表的属性
     * *************************************/
    public partial class frmTableProperty : Form
    {
        private string m_ConnectionString = string.Empty;

        #region 窗体单例模式
        private static frmTableProperty frm = null;
        public static frmTableProperty Instance
        {
            get
            {
                if (frm == null || frm.IsDisposed)
                {
                    frm = new frmTableProperty();
                }
                return frm;
            }
        }
        private frmTableProperty()
        {
            InitializeComponent();

            this.InitializeUcSelectDB();

            this.viewMain.BestFitMaxRowCount = 100;
            this.viewMain.OptionsView.ColumnAutoWidth = false;
            this.viewSub.BestFitMaxRowCount = 100;
            this.viewSub.OptionsView.ColumnAutoWidth = false;

            SetGridFooter(viewMain);
            SetGridFooter(viewSub);
        }

        #endregion

        #region 初始化UcSelectDB用户控件
        private void InitializeUcSelectDB()
        {
            DbTreeNode selectedNode = MainFormDX.ucDBTree.SelectedNode as DbTreeNode;
            if (selectedNode == null) return;
            SqlDataEngineSchema m_SqlDataEngine = selectedNode.AscendDbObjectSchema<SqlDataEngineSchema>();
            ucSelectDB1.CurrentServer = m_SqlDataEngine.SqlDataSourceInfo.DataSource;

            m_ConnectionString = m_SqlDataEngine.ConnectionString;
            ucSelectDB1.OnDBSelectedChange += DBSelectedChanged;

            DBHelper.SqlHelper.SqlConnectionString = m_ConnectionString;
            string sqlString = string.Format("select [name] from sys.databases order by [name] asc");
            ucSelectDB1.DBDataSource = DBHelper.SqlHelper.ExecuteDataTable(sqlString);

            DataBaseSchema m_DataBaseSchema = selectedNode.AscendDbObjectSchema<DataBaseSchema>();
            if (m_DataBaseSchema != null)
            {
                ucSelectDB1.SelectedDB = m_DataBaseSchema.Name;
            }
        }

        private void DBSelectedChanged(object sender, EventArgs e)
        {

            DBHelper.SqlHelper.SqlConnectionString = m_ConnectionString;
            string sqlString = string.Format(SqlSchemaHelper.ReadDataTableSql, ucSelectDB1.SelectedDB);
            this.gridMain.DataSource = DBHelper.SqlHelper.ExecuteDataTable(sqlString);
            this.viewMain.BestFitColumns();

            viewMain_FocusedRowChanged(null, null);
        }
        #endregion

        private void viewMain_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if ((e != null && e.FocusedRowHandle < 0) || viewMain.GetFocusedDataRow() == null)
            {
                this.gridSub.DataSource = null;
                return;
            }
            DBHelper.SqlHelper.SqlConnectionString = m_ConnectionString;
            string sqlScript = string.Format(SqlSchemaHelper.ReadColumnSqlScript, ucSelectDB1.SelectedDB);
            string tableName = viewMain.GetFocusedRowCellValue("Name").ToString();
            string tableSchema = viewMain.GetFocusedRowCellValue("Schema").ToString();
            SqlParameter[] sqlParams = new SqlParameter[]               
                { 
                  new SqlParameter("@TableName", tableName) ,
                  new SqlParameter("@TableSchema", tableSchema)
                 };
            this.gridSub.DataSource = DBHelper.SqlHelper.ExecuteDataTable(sqlScript, sqlParams);
            this.viewSub.BestFitColumns();
        }

        #region
        /// <summary>
        /// 设置Grid的汇总行
        /// </summary>
        void SetGridFooter(DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            if (view.Columns.Count > 1)
            {
                view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                view.Columns[0].SummaryItem.DisplayFormat = "总行数：";
                if (view.Columns[0].Width < 60) viewMain.Columns[0].Width = 60;
                view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            }
            else if (view.Columns.Count == 1)
            {
                view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                view.Columns[0].SummaryItem.DisplayFormat = "总行数：{0}";
                if (view.Columns[0].Width < 100) view.Columns[0].Width = 100;
            }
        }
        #endregion


        #region 更改表的定序
        public static void AlterTableCollation(string tableName)
        {
            DataTable dt = new DataTable();
            string strSQL = "select TABLE_NAME as TableName,COLUMN_NAME as ColumnName,DATA_TYPE as ColumnType,CHARACTER_MAXIMUM_LENGTH as StringLeng,NUMERIC_PRECISION as Xprec,NUMERIC_SCALE as Xscale  from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" + tableName + "'";
            dt = DBHelper.SqlHelper.ExecuteDataTable(strSQL);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                switch (dt.Rows[i]["ColumnType"].ToString())
                {
                    case "nvarchar":
                    case "varchar":
                    case "nchar":
                    case "char":
                        string strTemp = "ALTER TABLE [" + tableName + "] ALTER COLUMN [" + dt.Rows[i]["ColumnName"].ToString() + "] ";
                        if (Convert.ToInt32(dt.Rows[i]["StringLeng"].ToString()) == -1)
                        {
                            strTemp = strTemp + dt.Rows[i]["ColumnType"].ToString() + "(max)" + " COLLATE Chinese_PRC_CI_AS";
                        }
                        else
                        {
                            strTemp = strTemp + dt.Rows[i]["ColumnType"].ToString() + "(" + dt.Rows[i]["StringLeng"].ToString() + ")" + " COLLATE Chinese_PRC_CI_AS";
                        }
                        AlterColumnCollation(tableName, dt.Rows[i]["ColumnName"].ToString(), strTemp);
                        break;
                }
            }
        }
        #endregion

        #region 更改列的定序(參數alterSQL為更改定序的語句)
        private static void AlterColumnCollation(string tableName, string columnName, string alterSQL)
        {
            string indexName = string.Empty;
            string indexType = string.Empty;
            if (IsIndex(tableName, columnName, out indexName, out indexType) == true)
            {
                DBHelper.SqlHelper.ExecuteNonQuery("drop index [" + tableName + "].[" + indexName + "]");
                DBHelper.SqlHelper.ExecuteNonQuery(alterSQL);
                string strSQL = "create " + indexType + " index [" + indexName + "] on[" + tableName + "]([" + columnName + "])";
                DBHelper.SqlHelper.ExecuteNonQuery(strSQL);
            }
            else
            {
                DBHelper.SqlHelper.ExecuteNonQuery(alterSQL);
            }
        }

        #region 判斷指定表中的指定列是否為索引列
        private static bool IsIndex(string tableName, string columnName, out string indexName, out string indexType)
        {
            string strSQL = "SELECT indexname = a.name , tablename = c. name , indexcolumns = d .name , a .indid FROM  sysindexes a JOIN sysindexkeys b ON a .id = b .id  AND a .indid = b.indid " +
       " JOIN sysobjects c ON b .id = c .id JOIN syscolumns d ON b .id = d .id  AND b .colid = d .colid WHERE a .indid NOT IN ( 0 , 255 ) AND c .name = '" + tableName + "'";
            using (IDataReader sdr = DBHelper.SqlHelper.ExecuteDataReader(strSQL))
            {
                while (sdr.Read())
                {
                    if (sdr["indexcolumns"].ToString() == columnName)
                    {
                        indexName = sdr["indexname"].ToString();
                        if (Convert.ToInt32(sdr["indid"]) == 1)
                        {
                            indexType = "Clustered";
                        }
                        else
                        {
                            indexType = "Nonclustered";
                        }
                        return true;
                    }
                }
            }
            indexName = string.Empty;
            indexType = string.Empty;
            return false;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            AlterTableCollation(this.viewMain.GetFocusedRowCellValue("Name").ToString());
            MessageBox.Show("sucess");
        }

        #endregion

    }
}
