using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ICSharpCode.TextEditor.Document;
using CodeGenius.Entity;

namespace CodeGenius.frm
{
    public partial class QueryForm : BaseChildForm
    {
        readonly string ConnectionString;

        public QueryForm()
        {
            InitializeComponent();
            this.SetTextEditorControl();
        }

        public QueryForm(SqlDataEngineSchema engineSchema, DataBaseSchema dbSchema)
            : this()
        {
            if (engineSchema == null)
            {
                MessageBox.Show(string.Format("engineSchema 不能为空！"));
                return;
            }
            this.Text = engineSchema.SqlDataSourceInfo.DataSource;
            this.ConnectionString = engineSchema.ConnectionString;
            DBHelper.SqlHelper.SqlConnectionString = this.ConnectionString;
            string sqlString = string.Format("select [name] from sys.databases order by [name] asc");

            tscmb.Items.AddRange(DBHelper.SqlHelper.ExecuteDataTable(sqlString).Select().Select(a => a["name"]).ToArray());
            if (dbSchema != null)
            {
                tscmb.Text = dbSchema.Name;
            }
        }

        #region 设置TextEditorControl
        private void SetTextEditorControl()
        {
            txtContent.ShowEOLMarkers = false;
            txtContent.ShowVRuler = false;
            txtContent.ShowInvalidLines = false;
            txtContent.ShowTabs = false;
            txtContent.ShowSpaces = false;
            txtContent.Encoding = System.Text.Encoding.Default;
            txtContent.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");
        }
        #endregion


        public static void NewQueryForm(string strSQL, SqlDataEngineSchema engineSchema, DataBaseSchema dbSchema, bool excute = false)
        {
            QueryForm fr = new QueryForm(engineSchema, dbSchema);
            fr.txtContent.Text = strSQL;

            if (excute)
            {
                ExcuteSQLStatement(fr, dbSchema.ConnectionString, strSQL);
            }
            fr.splitContainer1.Panel2Collapsed = !excute;

            SetStatusStrip(fr, engineSchema.SqlDataSourceInfo, dbSchema.Name);

            fr.MdiParent = MainFormDX.Instance;
            fr.Show();
        }

        private static void ExcuteSQLStatement(QueryForm fr, string connectionString, string strSQL)
        {
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            DBHelper.SqlHelper.SqlConnectionString = connectionString;
            try
            {
                ds = DBHelper.SqlHelper.ExecuteDataSet(strSQL);
            }
            catch (Exception ex)
            {
                sb.AppendLine(ex.Message);
            }

            if (ds.Tables.Count > 0)
            {
                foreach (DataTable dt in ds.Tables)
                {
                    sb.AppendLine(string.Format("({0}行所影响)", dt.Rows.Count.ToString()));
                }
            }
            fr.rtxtMessage.Text = sb.ToString();
            if (ds != null && ds.Tables.Count > 0)
                fr.gridResult.DataSource = ds.Tables[0];
            else
                fr.gridResult.DataSource = null;
        }

        private static void SetStatusStrip(QueryForm fr, SqlDataSourceInfo dataSourceInfo, string currentDBName)
        {
            fr.tsslblServer.Text = string.Format("({0})({1})", dataSourceInfo.DataSource, dataSourceInfo.ProductLevel);
            fr.tsslblLoginName.Text = dataSourceInfo.UserID;
            fr.tsslblDB.Text = currentDBName;
        }

        private void tsbtnExcute_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2Collapsed = false;
            string sql = string.Format("use [{0}] {1}", tscmb.Text, this.txtContent.ActiveTextAreaControl.SelectionManager.SelectedText);
            ExcuteSQLStatement(this, this.ConnectionString, sql);
        }

    }
}
