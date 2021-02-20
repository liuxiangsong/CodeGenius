using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns; 

namespace Paging
{
    public partial class PagingControl : UserControl
    {
        public event FocusedRowChangedEventHandler OnRefreshGridSub;  //刷新子表的数据
        public PagingControl()
        {
            InitializeComponent();
        }

        #region 成员变量
        public DevExpress.XtraGrid.GridControl grid;     //使用前需賦值
        private string m_TableName;                     //使用前需賦值
        private string m_FieldsToReturn = " * ";        //需要返回的列
        private string m_FieldNameToSort ="AutoID" ;    //排序字段名称
        private string m_Strwhere = string.Empty;       //检索条件(注意: 不要加 where)

        private int m_PageSize = 100;
        private int m_PageCount = 0;
        private int m_RecordCount = 0;
        private int m_PageIndex = 1;
        #endregion

        #region 属性对象
        public string StrTableName
        {
            get { return m_TableName; }
            set { m_TableName = value; }
        }

        public string FieldsToReturn
        {
            get { return m_FieldsToReturn; }
            set { m_FieldsToReturn = value; }
        }

        public string FieldNameToSort
        {
            get { return m_FieldNameToSort; }
            set { m_FieldNameToSort = value; }
        }

        public string StrWhere
        {
            get { return m_Strwhere; }
            set { m_Strwhere = value; }
        }


        public int PageSize
        {
            set { this.m_PageSize = value; }
            get { return this.m_PageSize; }
        }

        public int PageCount
        {
            get
            {
                if (this.m_PageSize != 0)
                {
                    this.m_PageCount = GetPageCount();
                }
                return this.m_PageCount;
            }
        }

        public int RecordCount
        {
            set { this.m_RecordCount = value; }
            get { return this.m_RecordCount; }
        }

        public int PageIndex
        {
            set { this.m_PageIndex = value; }
            get { return this.m_PageIndex; }
        }
        #endregion

        private int GetPageCount()
        {
            if (this.m_PageSize == 0)
            {
                return 0;
            }
            if (this.m_RecordCount % this.m_PageSize == 0)
            {
                this.m_PageCount = this.m_RecordCount / this.m_PageSize;
            }
            else
            {
                this.m_PageCount = this.m_RecordCount / this.m_PageSize + 1;
            }
            return this.m_PageCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordCount">總記錄條數</param> 
        public void DrawControl(int recordCount)
        {
            this.m_RecordCount = recordCount;
            DrawControl(false);
        }

        private void DrawControl(bool callEvent)
        {
            this.lblPagingInfo.Text = string.Format("共 {0} 條記錄，每頁 {1} 條，共 {2} 頁", this.m_RecordCount, this.m_PageSize, this.PageCount);
            this.txtPageIndex.Text = this.m_PageIndex.ToString();
            //if (callEvent && OnPageChanged != null)
            //{ 
            //    OnPageChanged(this, null);//当前分页数字改变时，触发委托事件
            //}
            if (callEvent)
            {
                BindDataToGrid(); 
            }
            if (this.RecordCount == 0)
            {
                this.btnFirst.Enabled = false;
                this.btnPrevious.Enabled = false;
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
                this.txtPageIndex.Enabled = false;
                this.txtPageIndex.Text = "0";
                this.btnExport.Enabled = false;
                this.btnExportAll.Enabled = false;
            }
            else if (this.m_PageCount == 1) //有且仅有一页
            {
                this.btnFirst.Enabled = false;
                this.btnPrevious.Enabled = false;
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
                this.txtPageIndex.Enabled = false;
            }
            else if (this.m_PageIndex == 1)//第一页
            {
                this.btnFirst.Enabled = false;
                this.btnPrevious.Enabled = false;
                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;
            }
            else if (this.m_PageIndex == this.m_PageCount)//最后一页
            {
                this.btnFirst.Enabled = true;
                this.btnPrevious.Enabled = true;
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            this.m_PageIndex = 1;
            DrawControl(true);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.m_PageIndex = Math.Max(1, this.m_PageIndex - 1);
            DrawControl(true);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.m_PageIndex = Math.Min(this.m_PageCount, this.m_PageIndex + 1);
            DrawControl(true);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            this.m_PageIndex = this.m_PageCount;
            DrawControl(true);
        }

        private void txtPageIndex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int num = 0;
                if (int.TryParse(this.txtPageIndex.Text.Trim(), out num) && num > 0)
                {
                    this.m_PageIndex = num;
                }
                DrawControl(true);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (grid.MainView.DataRowCount < 1)
            {
                MessageBox.Show("沒有可供導出的數據", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ExportToExcel(grid);
        }
         
        private void btnExportAll_Click(object sender, EventArgs e)
        {
            StringBuilder sb=new StringBuilder(); 
            Dictionary<string, string> dic = new Dictionary<string, string>();
            
            sb.Append("select ");
           GridView view =(GridView)grid.MainView;
           foreach (GridColumn col in view.Columns)
           {
               if (col.Visible == true)
               { 
                   dic.Add(col.FieldName, col.Caption);
                   sb.Append(col.FieldName+",");
               }
           }
           if (sb.Length > 8)
           {
               string sqlString = sb.ToString().TrimEnd(',') + " from [" + m_TableName + "]";
               DataTable dt = SQLHelper.GetDataTable(sqlString);
               if (dt.Rows.Count < 1)
               {
                   MessageBox.Show("沒有可供導出的數據", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   return;
               }
               foreach (DataColumn dc in dt.Columns)
               {
                   dc.Caption = dic[dc.ColumnName];
               } 
               ExcelExport.ExportExcel(dt); 
           }
           else
           {
               MessageBox.Show("沒有可供導出的數據", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
        }

        #region 导出Excel操作
        private void ExportToExcel(GridControl tempGrid)
        {
            SaveFileDialog saveFileDialog = null;
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel 文件(*.xlsx)|*.xlsx|Excel 文件 (*.xls)|*.xls";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!saveFileDialog.FileName.Equals(String.Empty))
                {
                    tempGrid.ExportToXlsx(saveFileDialog.FileName);
                    if (MessageBox.Show("導出操作完成，您想打開該Excel文件嗎？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Process.Start(saveFileDialog.FileName);
                    }
                }
                else
                {
                    MessageBox.Show("請指定一個保存文件的目錄");
                }
            }
        }

        #endregion

        private void txtPageIndex_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            int num = 0;
            if (int.TryParse(e.NewValue.ToString(), out num))
            {
                if (num > PageCount)
                {
                    e.Cancel = true;
                }
            }
        }



        private void BindDataToGrid()
        {
            PagingHelper helper = new PagingHelper(m_TableName,m_FieldsToReturn, m_PageIndex, m_FieldNameToSort, m_PageSize, m_Strwhere);
            this.grid.DataSource = helper.GetDataTable();
            this.DrawControl(helper.GetRecordCount());
        }

        public void RefreshData(string strWhere)
        {
            this.m_Strwhere = strWhere;
            BindDataToGrid();
            if (OnRefreshGridSub != null)
                OnRefreshGridSub(null,null);
        }

        #region

        #endregion
    }
}
