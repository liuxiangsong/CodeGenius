using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using LibraryGenius;
using CodeGenius.Entity;
using System.IO;
using System.Threading;

namespace CodeGenius
{
    public partial class BrowseSQLServer : Form
    {
        private static List<SqlDataSourceInfo> m_InfoList;
        TreeViewMethods tvwMethod = new TreeViewMethods();

        #region Singleton Pattern
        private static BrowseSQLServer fr;

        public static BrowseSQLServer GetInstance()
        {
            if (fr == null || fr.IsDisposed)
            {
                fr = new BrowseSQLServer();
            }
            return fr;
        }

        private BrowseSQLServer()
        {
            InitializeComponent();
        }
        #endregion

        private void BrowseSQLServer_Load(object sender, EventArgs e)
        {
            if (m_InfoList == null && tvwLocal.Nodes.Count < 1)
            {
                tvwLocal.Nodes.Add("Database Engine");
                tvwNetwork.Nodes.Add("Database Engine");
                tvwMethod.AddSignleNode(tvwLocal.Nodes[0], "Loading Data......", "Loading");
                tvwMethod.AddSignleNode(tvwNetwork.Nodes[0], "Loading Data......", "Loading");
            }
        }

        private void LoadTreeView()
        {
            SqlDataSourceEnumerator se = SqlDataSourceEnumerator.Instance;
            m_InfoList = DataTableHelper.DataTableToList<SqlDataSourceInfo>(se.GetDataSources()); 

            BeginInvoke(
                (ThreadStart)(() =>
                {
                    tvwLocal.Nodes[0].Nodes.Clear();
                    tvwNetwork.Nodes[0].Nodes.Clear();
                    foreach (SqlDataSourceInfo info in m_InfoList)
                    {
                        string m_NodeText = info.ServerName + "\\" + info.InstanceName;
                        if (string.IsNullOrEmpty(info.InstanceName))
                        {
                            m_NodeText = m_NodeText.Remove(m_NodeText.LastIndexOf('\\'));
                        }
                        if (string.IsNullOrEmpty(info.Version) == false)
                        {
                            m_NodeText = m_NodeText + "\t    (" + info.Version.Remove(info.Version.LastIndexOf('.')) + ")";
                        }
                        if (info.ServerName == Environment.MachineName)
                        {
                            tvwMethod.AddSignleNode(tvwLocal.Nodes[0], m_NodeText, "Server");
                        }
                        tvwMethod.AddSignleNode(tvwNetwork.Nodes[0], m_NodeText, "Server");
                    }
                }));
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            btnOK.Enabled = (e.Node.Level == 1);
            ((TreeView)sender).SelectedImageKey = e.Node.ImageKey;
        }

        private void TreeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (m_InfoList == null)
            {
                //Application.DoEvents();
                Thread th = new Thread((ThreadStart)(() => { this.LoadTreeView(); }));
                th.Start();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TreeView m_TreeView;
            if (tabControl1.SelectedTab == tabPageLocal)
            {
                m_TreeView = tvwLocal;
            }
            else
            {
                m_TreeView = tvwNetwork;
            }
            if (m_TreeView.SelectedNode == null || m_TreeView.SelectedNode.Level != 1) return;
            string m_SelectedNodeText = m_TreeView.SelectedNode.Text;
            this.Owner.Tag = m_SelectedNodeText.Remove(m_SelectedNodeText.IndexOf("\t"));
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
