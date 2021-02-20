using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibraryGenius;
using CodeGenius.Entity;
using System.IO;
using CodeGenius.Frame.TreeNodeBase;
using System.CodeDom.Compiler;
using CodeGenius.CodeEngine;


namespace CodeGenius
{
    public partial class BatchCodeGenerator : Form
    {
        private string m_ConnectionString = string.Empty;
        IniFileHelper iniHelper = new IniFileHelper(Application.StartupPath + "/framework.ini");

        public BatchCodeGenerator()
        {
            InitializeComponent();
            this.InitializeUcSelectDB();
        }

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

            txtNamespace.Text = ucSelectDB1.SelectedDB;
        }
        #endregion

        private void BatchCodeGenerator_Load(object sender, EventArgs e)
        {
            if (!iniHelper.SectionExists("Section")) return;
            txtEntityPath.Text = iniHelper.ReadValue("Section", "EntityPath");
            txtDALPath.Text = iniHelper.ReadValue("Section", "DALPath");
            txtBLLPath.Text = iniHelper.ReadValue("Section", "BLLPath");
        }



        #region
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
        #endregion

        #region 選擇文件保存路徑
        private void btnEntityBrowse_Click(object sender, EventArgs e)
        {
            string selectedPath = FileDialogHelper.OpenDir(txtEntityPath.Text);
            if (selectedPath != string.Empty)
                txtEntityPath.Text = selectedPath;
        }

        private void btnDALBrowse_Click(object sender, EventArgs e)
        {
            string selectedPath = FileDialogHelper.OpenDir(txtDALPath.Text);
            if (selectedPath != string.Empty)
                txtDALPath.Text = selectedPath;
        }

        private void btnBLLBrowse_Click(object sender, EventArgs e)
        {
            string selectedPath = FileDialogHelper.OpenDir(txtBLLPath.Text);
            if (selectedPath != string.Empty)
                txtBLLPath.Text = selectedPath;
        }
        #endregion

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string entityTemplatePath = Path.Combine(Application.StartupPath, "Template", "Entity.tt");
            string dalTemplatePath = Path.Combine(Application.StartupPath, "Template", "Controller.tt");
            string bllTemplatePath = Path.Combine(Application.StartupPath, "Template", "BLL.tt");

            bool isGenerateEntity = Directory.Exists(txtEntityPath.Text);
            bool isGenerateDAL = Directory.Exists(txtDALPath.Text);
            bool isGenerateBLL = Directory.Exists(txtBLLPath.Text);

            try
            {
                bool flag = true;
                foreach (string tableName in lstSelectedTable.Items)
                {
                    if (isGenerateEntity)
                        flag = flag && this.GenerateFile(entityTemplatePath, tableName, Path.Combine(txtEntityPath.Text, tableName + "Info.Auto.cs"));
                    if (isGenerateDAL)
                    {
                        flag = flag && this.GenerateFile(dalTemplatePath, tableName, Path.Combine(txtDALPath.Text, tableName + "Controller.cs"));
                        string tempPath = Directory.GetParent(txtDALPath.Text).FullName;
                        //创建js文件
                        FileHepler.SaveFile(Path.Combine(tempPath, "ViewScript", tableName + ".js"), string.Empty,Encoding.UTF8);
                        string templatePath = Path.Combine(Application.StartupPath, "Template", "index.cshtml");
                        //创建视图
                        FileHepler.CreateDirectory(Path.Combine(tempPath, "Views", tableName, "index.cshtml"));
                        this.GenerateFile(templatePath, tableName, Path.Combine(tempPath, "Views", tableName, "index.cshtml")); 
                    }
                    if (isGenerateBLL)
                        flag = flag && this.GenerateFile(bllTemplatePath, tableName, Path.Combine(txtBLLPath.Text, tableName + ".cs"));
                }
                if (flag)
                {
                    MsgBox.ShowInformation("生成成功！");
                }
                else
                {
                    MsgBox.ShowInformation("生成失敗！");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool GenerateFile(string templateFilePath, string tableName, string filePath)
        {
            this.SaveFilePathRecord();
            if (File.Exists(filePath))
            {
                string message = string.Format("文件【{0}】已存在，是否覆蓋原文件？", Path.GetFileName(filePath));
                if (MsgBox.ShowYesNoQuestion(message) != DialogResult.Yes)
                    return false;
            }
            string m_TemplateContext = string.Empty;
            if (!File.Exists(templateFilePath))
            {
                MsgBox.ShowError("模版文件不存在");
                return false;
            }

            TemplateHost host = new TemplateHost();
            host.NameSpace = txtNamespace.Text;
            host.TableName = tableName;
            //tbInfo.Folder = "";
            host.Columns = SqlSchemaHelper.ReadTableColumnSchema(m_ConnectionString, ucSelectDB1.SelectedDB, tableName);
            m_TemplateContext = File.ReadAllText(templateFilePath);
            TemplateGenerator generator = new TemplateGenerator();
            try
            {
                string content = generator.Generate(m_TemplateContext, host);
                if (string.IsNullOrEmpty(content))
                {
                    MessageBox.Show(generator.ErrorMessage);
                    return false;
                }
                File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                MsgBox.ShowInformation(ex.Message);
                return false;
            }
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveFilePathRecord()
        {
            if (Directory.Exists(txtEntityPath.Text))
                iniHelper.WriteValue("Section", "EntityPath", txtEntityPath.Text.Trim());
            if (Directory.Exists(txtDALPath.Text))
                iniHelper.WriteValue("Section", "DALPath", txtDALPath.Text.Trim());
            if (Directory.Exists(txtBLLPath.Text))
                iniHelper.WriteValue("Section", "BLLPath", txtBLLPath.Text.Trim());
        }
    }
}
