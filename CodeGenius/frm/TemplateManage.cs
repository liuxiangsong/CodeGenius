using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

using System.IO;
using LibraryGenius;

namespace CodeGenius
{
    public partial class TemplateManage : DockContent
    {
        private readonly string m_InitialDir = Path.Combine(Application.StartupPath, "Template\\TemplateFile");
        private const string ExtensionName = ".cg";
        TreeViewMethods treeMethod = new TreeViewMethods();

        #region Singleton Pattern
        //单例模式（把构造方法私有化，外部代码不能直接实例化它）
        private static TemplateManage fr = null;
        private TemplateManage()
        {
            InitializeComponent();
        }

        public static TemplateManage GetInstance()
        {
            if (fr == null || fr.IsDisposed)
            {
                fr = new TemplateManage();
            }
            return fr;
        }
        #endregion

        private void TemplateManage_Load(object sender, EventArgs e)
        { 
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

        #region TreeView节点图标及展开与合并相关方法
        private void tvwTemplate_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Expand)
            {
                e.Node.ImageKey = "FolderOpen";
                //if (e.Node.Level == 0)
                //{
                //    tvwTemplate.SelectedImageKey = "FolderOpen";
                //}
            }
        }

        private void tvwTemplate_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Collapse)
            {
                e.Node.ImageKey = "FolderClose";
                //if (e.Node.Level == 0)
                //{
                //    tvwTemplate.SelectedImageKey = "FolderClose";
                //}
            }
        }

        private void tvwTemplate_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tvwTemplate.SelectedNode.SelectedImageKey = tvwTemplate.SelectedNode.ImageKey;
        }
        #endregion

        #region 设置右击菜单状态
        private void tvwTemplate_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tvwTemplate.SelectedNode = e.Node;
            }
        }

        private void tvwTemplate_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (tvwTemplate.SelectedNode.ImageKey == "File")
                {
                    this.SetContextMenuStatus(true);
                }
                else
                {
                    this.SetContextMenuStatus(false);
                }
            }
        }

        private void SetContextMenuStatus(bool isFile)
        {
            foreach (ToolStripItem tsi in cms.Items)
            {
                if (tsi.GetType() != typeof(ToolStripMenuItem)) continue;
                if (tsi.Name == "cmsRefresh"||tsi.Name =="cmsAdd")
                {
                    tsi.Visible = !isFile;
                    tsi.Enabled = !isFile;
                }
                else if (tsi.Name == "cmsEdit")
                {
                    tsi.Visible = isFile;
                    tsi.Enabled = isFile;
                }
            }
        }
        #endregion

        #region 右击菜单
        private void cmsAddFolder_Click(object sender, EventArgs e)
        {
            string m_NewFolderName = "新建文件夹";
            string m_NewFolderPath = string.Empty;
            int num = 0;
            DirectoryInfo dir = new DirectoryInfo(tvwTemplate.SelectedNode.Name);
            while (true)
            {
                if (dir.GetDirectories(m_NewFolderName).Length < 1)
                {
                    break;
                }
                num++;
                m_NewFolderName = "新建文件夹" + num;
            }
            m_NewFolderPath = Path.Combine(tvwTemplate.SelectedNode.Name, m_NewFolderName);
            tvwTemplate.SelectedNode = treeMethod.AddSignleNode(tvwTemplate.SelectedNode, m_NewFolderName, m_NewFolderPath, "FolderClose");
            tvwTemplate.SelectedNode.BeginEdit(); 
        }
        
        private void cmsAddTemplate_Click(object sender, EventArgs e)
        {
            string m_NewFileName = "新建模板"+ExtensionName;
            string m_NewFilePath = string.Empty;
            int num = 0;
            DirectoryInfo dir = new DirectoryInfo(tvwTemplate.SelectedNode.Name);
            while (true)
            {
                if (dir.GetFiles(m_NewFileName).Length < 1)
                {
                    break;
                }
                num++;
                m_NewFileName = "新建模板" + num + ExtensionName;
            }
            m_NewFilePath = Path.Combine(tvwTemplate.SelectedNode.Name, m_NewFileName);
            tvwTemplate.SelectedNode = treeMethod.AddSignleNode(tvwTemplate.SelectedNode, m_NewFileName, m_NewFilePath, "File");
            tvwTemplate.SelectedNode.BeginEdit(); 
        }

        private void tvwTemplate_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {     
                string m_Path = tvwTemplate.SelectedNode.Parent.Name + "\\" + e.Label; ;
                if (tvwTemplate.SelectedNode.ImageKey == "File")
                {
                    if (File.Exists(m_Path) && e.Label != null)
                    {
                        MsgBox.ShowInformation("文件：" + e.Label + "已存在，请重新命名");
                        e.CancelEdit = true;
                        return;
                    }
                    else if(e.Label != null)
                    {
                        tvwTemplate.SelectedNode.Name = m_Path;
                    }
                    File.Create(tvwTemplate.SelectedNode.Name);
                }
                else
                {
                    if (Directory.Exists(m_Path) && e.Label != null)
                    {
                        MsgBox.ShowInformation("文件夹：" + e.Label + "已存在，请重新命名");
                        e.CancelEdit = true;
                        return;
                    }
                    else if (e.Label != null)
                    {
                        tvwTemplate.SelectedNode.Name = m_Path;
                    }
                    Directory.CreateDirectory(tvwTemplate.SelectedNode.Name);
                }
           
        }

        private void cmsEdit_Click(object sender, EventArgs e)
        {

        }

        private void cmsRefresh_Click(object sender, EventArgs e)
        {
            tvwTemplate.SelectedNode.Nodes.Clear();
            this.BuildTree(tvwTemplate.SelectedNode.Name, tvwTemplate.SelectedNode);
        }

        private void cmsRename_Click(object sender, EventArgs e)
        {
            tvwTemplate.SelectedNode.BeginEdit();
        }

        private void cmsDelete_Click(object sender, EventArgs e)
        {
            if (tvwTemplate.SelectedNode.ImageKey == "File")
            {
                if (MsgBox.ConfirmYesNo("是否确认删除此文件") )
                {
                    File.Delete(tvwTemplate.SelectedNode.Name);
                    tvwTemplate.SelectedNode.Remove();
                }
            }
            else
            {
                if (MsgBox.ConfirmYesNo("是否确认删除此文件夹") )
                {
                    Directory.Delete(tvwTemplate.SelectedNode.Name,true);
                    tvwTemplate.SelectedNode.Remove();
                }
            }
        }

        private void cmsOpenFolder_Click(object sender, EventArgs e)
        {
            string m_Path = string.Empty;
            if (tvwTemplate.SelectedNode.ImageKey == "File")
            {
                m_Path = tvwTemplate.SelectedNode.Parent.Name;
            }
            else
            {
                m_Path = tvwTemplate.SelectedNode.Name;
            }
            System.Diagnostics.Process.Start(m_Path);
        }

        #endregion


    }
}
