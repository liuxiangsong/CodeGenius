using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CodeGenius.Entity;
using CodeGenius.Frame.TreeNodeBase; 
using MsSqlTree.TreeNode.Server;

namespace CodeGenius
{
    public partial class frmDBExplorer : BaseChildForm
    { 
        private SqlDataEngineSchema CurrentDataEngine { get; set; } 

        public DBTree TreeView
        {
            get { return dbTree1; }
        }

        #region Singleton Pattern
        //单例模式（把构造方法私有化，外部代码不能直接实例化它）
        private static frmDBExplorer frm = null;
        private frmDBExplorer()
        {
            InitializeComponent();
        }

        public static frmDBExplorer GetInstance()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new frmDBExplorer();
            }
            return frm;
        }
        #endregion


        #region
        private void CreateDataEngineNode()
        {
            DbTreeNode engineNode = new DataEngine_Node(CurrentDataEngine);            

            foreach (DataEngine_Node node in MainFormDX.DBTree.Nodes)
            {
                if (node.Text == engineNode.Text)
                {
                    MainFormDX.DBTree.SelectedNode = node;
                    return;
                }
            }

            engineNode.DataEngineSchema = CurrentDataEngine;
            engineNode.CurrentObjectSchema = CurrentDataEngine;
            dbTree1.TreeView.SuspendLayout();
            try
            {
                dbTree1.TreeView.Nodes.Add(engineNode);
                dbTree1.TreeView.SelectedNode = engineNode;
                TreeNode expandNode = dbTree1.TreeView.SelectedNode;
                if (expandNode != null)
                {
                    expandNode.Expand();
                }
            }
            finally
            {
                dbTree1.TreeView.ResumeLayout();
            }

        }
        #endregion

        private void frmDBExplorer_Load(object sender, EventArgs e)
        {
            dbTree1.ListImage = DbTreeNode.ListImage;
            dbTree1.TreeView.ShowLines = false;

            dbTree1.TreeView.BeforeExpand += TreeViewBeforeExpand;
        }

        private static void TreeViewBeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node is DbTreeNode)
            {
                DbTreeNode node = (DbTreeNode)(e.Node);
                if (node.OnBeforeExpand != null)
                    node.OnBeforeExpand(node);
            }
        }


        private void tsmDBConnect_Click(object sender, EventArgs e)
        {
            SqlDBConnection fr = SqlDBConnection.GetInstance();
            fr.ShowDialog();
            if (fr.DialogResult != DialogResult.OK) return;
            CurrentDataEngine = fr.CurrentDataEngine;
            this.CreateDataEngineNode();
        }

        private void tsmDisconnect_Click(object sender, EventArgs e)
        {
            TreeNode treeNode = MainFormDX.DBTree.SelectedNode;
            while (treeNode.Parent != null)
            {
                treeNode = treeNode.Parent;
            }
            treeNode.Remove();
        }

        private void tsmRefresh_Click(object sender, EventArgs e)
        {
            frmDBExplorer.GetInstance().TreeView.RefreshCurrentNode();
        }


    }
}
