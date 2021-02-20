using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;

namespace CodeGenius
{
    public partial class SingleCodeGenerator : Form
    {     
        //al：The First Item is SQL Connection String;The Second Item is ServerName;
        //The Third Item is DataBase Name
        private ArrayList _al = null;
        public ArrayList al
        {
            set { _al = value; }
        }

        #region Singleton Pattern
        private static SingleCodeGenerator frm;
        public static SingleCodeGenerator GetInstance()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new SingleCodeGenerator();
            }
            return frm;
        }

        private SingleCodeGenerator()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Load Event
        private void SingleCodeGenerator_Load(object sender, EventArgs e)
        {
            DBHelper.SqlHelper.SqlConnectionString = _al[0].ToString();
            DataTable dt = DBHelper.SqlHelper.ExecuteDataTable("select name from sys.databases");
            dt.DefaultView.Sort="name asc";
            cboDataBase.DataSource = dt;
            lblCurrentServer.Text += _al[1].ToString();
            cboDataBase.SelectedText = _al[2].ToString();
        }
        #endregion

        private void cboDataBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBHelper.SqlHelper.SqlConnectionString = _al[0].ToString();
            string sqlString = "use [" + cboDataBase.Text + "] select name from sys.tables";
            if (string.IsNullOrEmpty(txtContain.Text.Trim()) == false)
            {
                sqlString += " where name like '%" + txtContain.Text.Trim() + "%'";
            }
            DataTable dtTable = DBHelper.SqlHelper.ExecuteDataTable(sqlString);
            dtTable.DefaultView.Sort = "name asc";
            cboTable.DataSource = dtTable;
        }

        private void cboTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtClassName.Text = cboTable.Text;
            string sqlConnectionString = _al[0].ToString();
            sqlConnectionString = Regex.Replace(sqlConnectionString, @"database=(.+?);", "");
            sqlConnectionString += "database='" + cboDataBase.Text + "';";
            DataTable dtTable = DBHelper.SqlUtil.GetSqlTableInfo(cboTable.Text, sqlConnectionString);
            DataColumn dc = new DataColumn("Select", typeof(Boolean));
            dc.DefaultValue = "false";
            dtTable.Columns.Add(dc);
            dc.SetOrdinal(0);
            dataGridView1.DataSource = dtTable;
        }

        #region 全选、反选、清空等按钮事件
        private void btnSelectOperation(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            switch (((Button)sender).Name)
            {
                case "btnSelectAll":
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr[0] = true;
                    }
                    break;
                case "btnInverse":
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr[0] = !Boolean.Parse(dr[0].ToString());
                    }
                    break;
                case "btnClear":
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr[0] = false;
                    }
                    break;
            }
        }

        private void btnSetConditon_Click(object sender, EventArgs e)
        {
            cboCondition.Items.Clear();
            DataTable dt = (DataTable)dataGridView1.DataSource;
            foreach (DataRow dr in dt.Rows)
            {
                if (Boolean.Parse(dr[0].ToString()) == true)
                {
                    cboCondition.Items.Add(dr["ColumnName"].ToString());
                }
            }
        }
        #endregion

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSaveFilePath.Text.Trim()))
            {
                MessageBox.Show("The file savepath cann't be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //string strSaveFilePath = txtSaveFilePath.Text + "\\" + cboTable.Text;
            string strSaveFilePath = txtSaveFilePath.Text;
            if (tabControl1.SelectedTab == tabPageVB)
            {
                this.GenerateLFTwoTier(strSaveFilePath);
            }
            else
            {
                this.GenerateLFThreeTier(strSaveFilePath);
            }
        }

        private void GenerateLFThreeTier(string saveFilePath)
        {
            if (!(chkCSModel.Checked || chkCSDAL.Checked || chkCSBLL.Checked || chkCSDALCommon.Checked))
            {
                MessageBox.Show("没有要生成的文件，请选择要生成的文件类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sqlConnectionString = _al[0].ToString();
            sqlConnectionString = Regex.Replace(sqlConnectionString, @"database=(.+?);", "");
            sqlConnectionString += "database='" + cboDataBase.Text + "';";
            DataTable tableColumnInfo = DBHelper.SqlUtil.GetSqlTableInfo(cboTable.Text, sqlConnectionString);

            CSharp.LFThreeTier lf = new CSharp.LFThreeTier(txtTLN.Text.Trim(), txtSubfolder.Text.Trim(), cboTable.Text);
            string strTemp=string.Empty;
            if (chkCSModel.Checked == true)
            {
                strTemp = lf.GenerateModelLayer(tableColumnInfo);
                Methods.SaveFile(saveFilePath, strTemp, cboTable.Text + "Info.cs");
            }
            if (chkCSDAL.Checked == true)
            {
                strTemp = lf.GenerateDALLayer(tableColumnInfo);
                Methods.SaveFile(saveFilePath, strTemp, "DAL"+cboTable.Text + ".cs");
            }
            if (chkCSBLL.Checked == true)
            {
                strTemp = lf.GenerateBLLLayer(tableColumnInfo);
                Methods.SaveFile(saveFilePath, strTemp, "BLL" + cboTable.Text + ".cs");
            }
            if (chkCSDALCommon.Checked == true)
            {
                strTemp = lf.GenerateDALCommonClass();
                Methods.SaveFile(saveFilePath, strTemp, "DALBase.cs");
            }
            MessageBox.Show("生成成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GenerateLFTwoTier(string saveFilePath)
        {
            if (cboCondition.Items.Count < 1)
            {
                MessageBox.Show("Codition field cann't be empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!(chkVBModel.Checked || chkVBMiddle.Checked || chkVBProcedure.Checked))
            {
                MessageBox.Show("没有要生成的文件，请选择要生成的文件类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sqlConnectionString = _al[0].ToString();
            sqlConnectionString = Regex.Replace(sqlConnectionString, @"database=(.+?);", "");
            sqlConnectionString += "database='" + cboDataBase.Text + "';";
            DataTable tableColumnInfo = DBHelper.SqlUtil.GetSqlTableInfo(cboTable.Text, sqlConnectionString);
            string strIdentityColumn = DBHelper.SqlUtil.GetSqlTableIdentityColumn(cboTable.Text);

            ArrayList conditionList = new ArrayList();
            foreach (object obj in cboCondition.Items)
            {
                conditionList.Add(obj);
            }

            VB.LFTwoTier lf = new VB.LFTwoTier(txtTLN.Text.Trim(), txtSubfolder.Text.Trim(), cboTable.Text);
            if (chkVBModel.Checked == true)
            {
                string strModel = lf.GenerateModelLayer(tableColumnInfo);
                Methods.SaveFile(saveFilePath, strModel, cboTable.Text + "Info.vb");
            }
            if (chkVBMiddle.Checked == true)
            {
                string strDAL = lf.GenerateDALLayer(tableColumnInfo, strIdentityColumn, conditionList);
                Methods.SaveFile(saveFilePath, strDAL, cboTable.Text + "_Controller.vb");
            }
            if (chkVBProcedure.Checked == true)
            {
                string strProc = lf.GenerateProc(tableColumnInfo, strIdentityColumn, conditionList);
                Methods.SaveFile(saveFilePath, strProc, cboTable.Text + ".sql");
            }
            MessageBox.Show("生成成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtSaveFilePath.Text = fbd.SelectedPath;
            }
        }

        #region RadioButton Event

        private void rbLFTwoTier_CheckedChanged(object sender, EventArgs e)
        {
            gbxLFTwoTier.Visible = rbLFTwoTier.Checked;
        }
        #endregion

        private void SingleCodeGenerator_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

    }
}
