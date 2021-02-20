using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using CodeGenius.Entity;
using CodeGenius.Frame.TreeNodeBase;
using System.Data.SqlClient;

namespace CodeGenius
{
    public partial class GenerateDBDoc : Form
    {  
        private string m_ConnectionString = string.Empty;
        #region Form Load Event

        public GenerateDBDoc()
        {
            InitializeComponent();
            SqlCodeGenerator.DBDataDocWord.SetProcessBarEvent += new SqlCodeGenerator.DBDataDocWord.SetProcessBarHandler(SetProcessBarValue);
            SqlCodeGenerator.DBDataDocHtml.SetProcessBarEvent += new SqlCodeGenerator.DBDataDocHtml.SetProcessBarHandler(SetProcessBarValue);
            this.InitializeUcSelectDB();
        }

        private void GenerateDBDoc_Load(object sender, EventArgs e)
        {

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
            lstUnSelectedTable.Items.Clear();
            lstSelectedTable.Items.Clear();
            DBHelper.SqlHelper.SqlConnectionString = m_ConnectionString;
            string sqlString = string.Format("use [{0}] select name from sys.tables order by name asc", ucSelectDB1.SelectedDB);
            DataTable dtTable = DBHelper.SqlHelper.ExecuteDataTable(sqlString);
            foreach (DataRow dr in dtTable.Rows)
            {
                lstUnSelectedTable.Items.Add(dr[0].ToString());
            }
            this.ListBoxItemCountChanged();
        }
        #endregion
                 
        private void ListBox_DoubleClick(object sender, EventArgs e)
        {
            if (sender == lstUnSelectedTable)
            {
                lstSelectedTable.Items.Add(lstUnSelectedTable.SelectedItem);
                lstUnSelectedTable.Items.Remove(lstUnSelectedTable.SelectedItem);
            }
            else
            {
                lstUnSelectedTable.Items.Add(lstSelectedTable.SelectedItem);
                lstSelectedTable.Items.Remove(lstSelectedTable.SelectedItem);
            }
            this.ListBoxItemCountChanged();
        }

        private void AddOrRemoveButton_Click(object sender, EventArgs e)
        {
            int selectedCount = 0; //選中的個數
            try
            {
                switch (((Button)sender).Name)
                {
                    case "btnAddAll":
                        lstSelectedTable.Items.AddRange(lstUnSelectedTable.Items);
                        lstUnSelectedTable.Items.Clear();
                        break;
                    case "btnAdd":
                        ListBox.SelectedObjectCollection lstUnSelectedItems = lstUnSelectedTable.SelectedItems;
                        selectedCount = lstUnSelectedTable.SelectedItems.Count;
                        for (int i = 0; i < selectedCount; i++)
                        {
                            lstSelectedTable.Items.Add(lstUnSelectedItems[i]);
                        }
                        for (int i = 0; i < selectedCount; i++)
                        {
                            lstUnSelectedTable.Items.Remove(lstUnSelectedItems[0]);
                        }
                        break;
                    case "btnRemove":
                        ListBox.SelectedObjectCollection lstSelectedItems = lstSelectedTable.SelectedItems;
                        selectedCount = lstSelectedTable.SelectedItems.Count;
                        for (int i = 0; i < selectedCount; i++)
                        {
                            lstUnSelectedTable.Items.Add(lstSelectedItems[i]);
                        }
                        for (int i = 0; i < selectedCount; i++)
                        {
                            lstSelectedTable.Items.Remove(lstSelectedItems[0]);
                        }
                        break;
                    case "btnRemoveAll":
                        lstUnSelectedTable.Items.AddRange(lstSelectedTable.Items);
                        lstSelectedTable.Items.Clear();
                        break;
                }
            }
            catch
            { }
            this.ListBoxItemCountChanged();
        }

        private void ListBoxItemCountChanged()
        {
            if (lstUnSelectedTable.Items.Count == 0)
            {
                btnAdd.Enabled = false;
                btnAddAll.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
                btnAddAll.Enabled = true;
            }

            if (lstSelectedTable.Items.Count == 0)
            {
                btnRemove.Enabled = false;
                btnRemoveAll.Enabled = false;
                btnGenerate.Enabled = false;
            }
            else
            {
                btnRemove.Enabled = true;
                btnRemoveAll.Enabled = true;
                btnGenerate.Enabled = true;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            progressBar1.Value = 0;
            progressBar1.Maximum = lstSelectedTable.Items.Count;

            string dbName = this.ucSelectDB1.SelectedDB;
            DataSet ds = new DataSet();
            DataTable dt;
            string commandText = string.Format(SqlSchemaHelper.ReadColumnSqlScript, dbName);
            foreach (string tableName in lstSelectedTable.Items)
            {
                SqlParameter[] sqlParams = new SqlParameter[]               
                { 
                  new SqlParameter("@TableName", tableName) ,
                  new SqlParameter("@TableSchema", "dbo")
                 };
                dt = DBHelper.SqlHelper.ExecuteDataTable(commandText, sqlParams);
                dt.TableName = tableName;
                ds.Tables.Add(dt.DefaultView.ToTable());
            }

            if (rbWord.Checked == true)
            {
                SqlCodeGenerator.DBDataDocWord generateDocWord = new SqlCodeGenerator.DBDataDocWord();
                generateDocWord.GenerateDocDBDocument(dbName, ds);
                MessageBox.Show("生成成功");
            }
            else
            {
                string templateFilePath = Application.StartupPath + @"\Template\table.htm";
                string str = SqlCodeGenerator.DBDataDocHtml.GenerateHtmlDBDocument(dbName, ds, templateFilePath);
                SaveFileDialog dialog = new SaveFileDialog
                {
                    Title = "Save File",
                    Filter = "htm files (*.htm)|*.htm|All files (*.*)|*.*"
                };
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(dialog.FileName, false, Encoding.Default);
                    writer.Write(str);
                    writer.Flush();
                    writer.Close();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void SetProcessBarValue(int value)
        {
            progressBar1.Value = value;
            Application.DoEvents();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GenerateDBDoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

    }
}
