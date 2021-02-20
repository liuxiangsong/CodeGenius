using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeGenius.Frame.TreeNodeBase;
using MsSqlTree.TreeNode.Server;
using CodeGenius.Entity;

namespace CodeGenius.UserControls
{
    public partial class ucDBExplorer : UserControl
    {
        private SqlDataEngineSchema CurrentDataEngine { get; set; }

        public DBTree ucDBTree
        {
            get { return dbTree1; }
        }

        public ucDBExplorer()
        {
            InitializeComponent();

            dbTree1.ListImage = DbTreeNode.ListImage;
            dbTree1.TreeViewMain.ShowLines = false;

            dbTree1.TreeViewMain.BeforeExpand += TreeViewBeforeExpand;
        }

        #region
        private void CreateDataEngineNode()
        {
            DbTreeNode engineNode = new DataEngine_Node(CurrentDataEngine);

            foreach (DataEngine_Node node in MainFormDX.ucDBTree.Nodes)
            {
                if (node.Text == engineNode.Text)
                {
                    MainFormDX.ucDBTree.SelectedNode = node;
                    return;
                }
            }

            engineNode.DataEngineSchema = CurrentDataEngine;
            engineNode.CurrentObjectSchema = CurrentDataEngine;
            dbTree1.TreeViewMain.SuspendLayout();
            try
            {
                dbTree1.TreeViewMain.Nodes.Add(engineNode);
                dbTree1.TreeViewMain.SelectedNode = engineNode;
                TreeNode expandNode = dbTree1.TreeViewMain.SelectedNode;
                if (expandNode != null)
                {
                    expandNode.Expand();
                }
            }
            finally
            {
                dbTree1.TreeViewMain.ResumeLayout();
            }

        }
        #endregion

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
            TreeNode treeNode = MainFormDX.ucDBTree.SelectedNode;
            while (treeNode.Parent != null)
            {
                treeNode = treeNode.Parent;
            }
            treeNode.Remove();
        }

        private void tsmRefresh_Click(object sender, EventArgs e)
        {
            MainFormDX.ucDBTree.RefreshCurrentNode();
        }
    }
}
