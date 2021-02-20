using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CodeGenius.Entity;
using LibraryGenius;
using CodeGenius.Frame.TreeNodeBase;

namespace CodeGenius
{
    public partial class frmViewTableData : Form
    {
        DataBaseSchema dbSchema;
        TableSchema tableSchema;
        ViewSchema viewSchema;

        #region 窗体初始化
        private static frmViewTableData frm = null;
        public static frmViewTableData Instance
        {
            get
            {
                if (frm == null || frm.IsDisposed)
                {
                    frm = new frmViewTableData();
                }
                return frm;
            }
        }
        private frmViewTableData()
        {
            InitializeComponent();
            MainFormDX.ucDBTree.OnNodeSelect += new NodeEventHandler(ucDBTree_OnNodeSelect);
        }

        void ucDBTree_OnNodeSelect(Frame.TreeNodeBase.DbTreeNode sender, EventArgs e, Entity.DBObjectSchema dbObjectSchema)
        {
            if (dbObjectSchema is TableSchema || dbObjectSchema is ViewSchema)
            {
                dbSchema = sender.AscendDbObjectSchema<DataBaseSchema>();
                if (dbObjectSchema is TableSchema)
                {
                    tableSchema = dbObjectSchema as TableSchema;
                }
                else
                {
                    viewSchema = dbObjectSchema as ViewSchema;
                }
                this.SetFormText();
                this.ExecuteSelect();
            }
        }

        #endregion

        #region 设置窗体显示文本
        /// <summary>
        /// 设置窗体显示文本
        /// </summary>
        void SetFormText()
        {
            if (tableSchema != null)
            {
                this.Text = string.Format("查看表【{0}.{1}.{2}】数据", dbSchema.Name, tableSchema.Schema, tableSchema.Name);
            }
            else if (viewSchema != null)
            {
                this.Text = string.Format("查看视图【{0}.{1}.{2}】数据", dbSchema.Name, viewSchema.Schema, viewSchema.Name);
            }
        }
        #endregion

        #region 载入窗体
        private void frmViewTableData_Load(object sender, EventArgs e)
        {
            this.viewMain.BestFitMaxRowCount = 100;
            this.viewMain.OptionsView.ColumnAutoWidth = false;
            DbTreeNode selectedNode = MainFormDX.ucDBTree.SelectedNode as DbTreeNode;
            if (selectedNode == null) return;
            if (selectedNode.CurrentObjectSchema is TableSchema || selectedNode.CurrentObjectSchema is ViewSchema)
            {
                dbSchema = selectedNode.AscendDbObjectSchema<DataBaseSchema>();
                if (selectedNode.CurrentObjectSchema is TableSchema)
                {
                    tableSchema = selectedNode.CurrentObjectSchema as TableSchema;
                }
                else
                {
                    viewSchema = selectedNode.CurrentObjectSchema as ViewSchema;
                }
                this.SetFormText();
                this.ExecuteSelect();
            }
        }
        #endregion

        #region 执行查询语句
        /// <summary>
        /// 执行查询语句
        /// </summary>
        void ExecuteSelect()
        {
            string commandText = "SELECT Top {0} * FROM [{1}].[{2}].[{3}] ";
            if (tableSchema != null)
            {
                commandText = string.Format(commandText, this.txtRowCount.Text, dbSchema.Name, tableSchema.Schema, tableSchema.Name);
            }
            else if (viewSchema != null)
            {
                commandText = string.Format(commandText, this.txtRowCount.Text, dbSchema.Name, viewSchema.Schema, viewSchema.Name);
            }
            else
            {
                MsgBox.ShowInformation(MessageInfo.MsgInfo301);
                return;
            }
            DBHelper.SqlHelper.SqlConnectionString = dbSchema.ConnectionString;
            this.viewMain.Columns.Clear();
            this.gridMain.DataSource = DBHelper.SqlHelper.ExecuteDataTable(commandText);
            this.viewMain.BestFitColumns();
            this.SetGridFooter();
        }

        /// <summary>
        /// 设置Grid的汇总行
        /// </summary>
        void SetGridFooter()
        {
            if (this.viewMain.Columns.Count > 1)
            {
                this.viewMain.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                this.viewMain.Columns[0].SummaryItem.DisplayFormat = "总行数：";
                if (this.viewMain.Columns[0].Width < 60) this.viewMain.Columns[0].Width = 60;
                this.viewMain.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            }
            else if (this.viewMain.Columns.Count == 1)
            {
                this.viewMain.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                this.viewMain.Columns[0].SummaryItem.DisplayFormat = "总行数：{0}";
                if (this.viewMain.Columns[0].Width < 100) this.viewMain.Columns[0].Width = 100;
            }
        }
        #endregion

        #region 查询
        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.ExecuteSelect();
        }
        #endregion

        private void frmViewTableData_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MainFormDX.ucDBTree != null )
                MainFormDX.ucDBTree.OnNodeSelect -= new NodeEventHandler(ucDBTree_OnNodeSelect);
        }

    }
}
