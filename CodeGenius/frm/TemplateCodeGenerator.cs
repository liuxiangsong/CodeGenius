using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using LibraryGenius;
using System.IO;
using CodeGenius.Entity;

namespace CodeGenius 
{
    public partial class TemplateCodeGenerator : Form
    {
        //al：The First Item is SQL Connection String;The Second Item is ServerName;
        //The Third Item is DataBase Name
        private ArrayList _al;
        public ArrayList al
        {
            set { _al = value; }
        }
        private readonly string m_InitialDir = Path.Combine(Application.StartupPath, "Template\\TemplateFile");
        private const string ExtensionName = ".cg";
        TreeViewMethods treeMethod = new TreeViewMethods();

        #region Form Load Event

        #region Singleton Pattern
        private static TemplateCodeGenerator fr = null;
        public static TemplateCodeGenerator GetInstance()
        {
            if (fr == null || fr.IsDisposed)
            {
                fr = new TemplateCodeGenerator();
            }
            return fr;
        }

        private TemplateCodeGenerator()
        {
            InitializeComponent();
            //SqlCodeGenerator.DBDataDocWord.SetProcessBarEvent += new SqlCodeGenerator.DBDataDocWord.SetProcessBarHandler(SetProcessBarValue);
            //SqlCodeGenerator.DBDataDocHtml.SetProcessBarEvent += new SqlCodeGenerator.DBDataDocHtml.SetProcessBarHandler(SetProcessBarValue);
        }
        #endregion 
         
        private void TemplateCodeGenerator_Load(object sender, EventArgs e)
        {
            DBHelper.SqlHelper.SqlConnectionString = _al[0].ToString();
            DataTable dtTable = DBHelper.SqlHelper.ExecuteDataTable("select name from sys.databases");
            dtTable.DefaultView.Sort = "name asc";
            cboDataBase.DataSource = dtTable;
            lblCurrentServer.Text += _al[1].ToString();
            cboDataBase.SelectedText = _al[2].ToString();

            tvwTemplate.Nodes.Add("代码模板").Name = m_InitialDir;
            tvwTemplate.Nodes[m_InitialDir].ImageKey = "FolderClose";
            BuildTree(m_InitialDir, tvwTemplate.Nodes[m_InitialDir]);
            tvwTemplate.Nodes[m_InitialDir].Expand();
        }

        private void BuildTree(string dirPath, TreeNode parentNode)
        {
            DirectoryInfo dir = new DirectoryInfo(dirPath);
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                treeMethod.AddSignleNode(parentNode, d.Name, d.FullName, "FolderClose");
                BuildTree(d.FullName, parentNode.Nodes[d.FullName]);
            }
            foreach (FileInfo f in dir.GetFiles("*" + ExtensionName))
            {
                treeMethod.AddSignleNode(parentNode, f.Name, f.FullName, "File");
            }
        }
        #endregion

        #region MyRegion
        private void cboDataBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstUnSelectedTable.Items.Clear();
            lstSelectedTable.Items.Clear();
            string m_SqlConnectionString=_al[0].ToString().Remove(_al[0].ToString().IndexOf(";database"));
            DBHelper.SqlHelper.SqlConnectionString = m_SqlConnectionString + ";database='" + cboDataBase.Text + "';"; 
            string sqlString = "select name from sys.tables order by name asc";
            DataTable dtTable = DBHelper.SqlHelper.ExecuteDataTable(sqlString);
            foreach (DataRow dr in dtTable.Rows)
            {
                lstUnSelectedTable.Items.Add(dr[0].ToString());
            }
            this.ListBoxItemCountChanged();
        }

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
                //btnGenerate.Enabled = false;
            }
            else
            {
                btnRemove.Enabled = true;
                btnRemoveAll.Enabled = true;
                //btnGenerate.Enabled = true;
            }
        } 
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region TreeView节点图标及展开与合并相关方法
        private void tvwTemplate_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Expand)
            {
                e.Node.ImageKey = "FolderOpen"; 
            }
        }

        private void tvwTemplate_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Collapse)
            {
                e.Node.ImageKey = "FolderClose"; 
            }
        }

        private void tvwTemplate_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tvwTemplate.SelectedNode.SelectedImageKey = tvwTemplate.SelectedNode.ImageKey;
        }
        #endregion

        private void tvwTemplate_DoubleClick(object sender, EventArgs e)
        {
            if (tvwTemplate.SelectedNode == null) return;
            if (tvwTemplate.SelectedNode.ImageKey != "File") return;
            lstTemplate.Items.Add(GetNodeRelativePath(tvwTemplate.SelectedNode)); 
        }

        private string GetNodeRelativePath(TreeNode node)
        {
            string m_Path = node.Text;
            TreeNode m_Node = node;
            while (m_Node.Level > 1)
            {
                m_Node = m_Node.Parent;
                m_Path = Path.Combine(m_Node.Text, m_Path);
            }
            return m_Path;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string connectionString = "server='.';database='demosql';uid='sa';pwd='123';"; 
            string m_TemplateFilePath = @"D:\C#\CodeGenius\CodeGenius\Template\ORMModel.cshtml";
            string m_TemplateContext = string.Empty;
            if (File.Exists(m_TemplateFilePath))
            {
                TableInfo tbInfo = new TableInfo();
                tbInfo.TableName = "Purchase";
                tbInfo.NameSpace = "Lau";
                tbInfo.Folder = "1"; 
                tbInfo.Columns = SqlSchemaHelper.ReadTableColumnSchema(connectionString, "DemoSQL", tbInfo.TableName);
                m_TemplateContext = File.ReadAllText(m_TemplateFilePath);
                try
                {
                    RazorEngine.Razor.DefaultTemplateService.Namespaces.Add("CodeGenius.DBSchema");
                    RazorEngine.Razor.DefaultTemplateService.Namespaces.Add("CodeGenius");
                    RazorEngine.Razor.DefaultTemplateService.Namespaces.Add("LibraryGenius");
                    string s = RazorEngine.Razor.Parse(m_TemplateContext, new { tableInfo = tbInfo });
                    File.WriteAllText("D:\\1.cs", s);
                    MessageBox.Show("生成成功");
                }
                catch (Exception ex)
                {
                    MsgBox.ShowInformation(ex.Message);
                } 
            }

            ////string m_TemplateFilePath = string.Empty;
            //string m_TemplateContext = string.Empty;
            ////m_TemplateFilePath = Path.Combine(m_InitialDir, lstTemplate.Items[0].ToString());
            //string m_TemplateFilePath = @"F:\mywork\CodeGenius\CodeGenius\Template\ORMModel.cshtml";
            //if (File.Exists(m_TemplateFilePath))
            //{
            //    TableInfo tbInfo = new TableInfo();
            //    tbInfo.TableName = lstSelectedTable.Items[0].ToString();
            //    tbInfo.NameSpace = "Lau";
            //    tbInfo.Folder = "1";
            //    DataTable dt = DBHelper.SqlUtil.GetSqlTableInfo(lstSelectedTable.Items[0].ToString());
            //    ConvertToList toList = new ConvertToList();
            //    //tbInfo.Columns =toList.ConvertToColumnList(dt);
            //    m_TemplateContext = File.ReadAllText(m_TemplateFilePath);
                 

            //    TableInfo tbInfo = new TableInfo();
            //    tbInfo.TableName = "Purchase";
            //    tbInfo.NameSpace = "Lau";
            //    tbInfo.Folder = "1"; 
            //    tbInfo.Columns = SqlSchemaHelper.ReadTableColumnSchema(connectionString, "DemoSQL", tbInfo.TableName);
            //    m_TemplateContext = File.ReadAllText(m_TemplateFilePath);
            //    try
            //    {
            //        RazorEngine.Razor.DefaultTemplateService.Namespaces.Add("CodeGenius.DBSchema");
            //        RazorEngine.Razor.DefaultTemplateService.Namespaces.Add("CodeGenius");
            //        RazorEngine.Razor.DefaultTemplateService.Namespaces.Add("LibraryGenius");
            //        string s = RazorEngine.Razor.Parse(m_TemplateContext, new { tableInfo = tbInfo });
            //        File.WriteAllText("D:\\1.cs", s);
            //        MessageBox.Show("生成成功");
            //    }
            //    catch (Exception ex)
            //    {
            //        MsgBox.ShowInformation(ex.Message);
            //    }
            //}
        }

        private void TemplateCodeGenerator_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

    }
}
