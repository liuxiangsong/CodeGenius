using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;

namespace CodeGenius
{
    public delegate void NodeEventHandler(DbTreeNode sender, EventArgs e, DBObjectSchema dbObjectSchema);
    public partial class DBTree : UserControl
    { 
        #region 变量及属性定义
        public event NodeEventHandler OnNodeSelect;     //节点选中事件
        //public event NodeEventHandler OnNodeClick;      //节点点击事件
        public event NodeLabelEditEventHandler AfterLabelEdit;

        #region ImageList定义及相关方法
        protected ImageList listImage = null;
        /// <summary>
        /// 集合中的图片，要往其中添加图片请使用 AddImage(*) 函数；
        /// </summary>
        public ImageList ListImage
        {
            get { return this.listImage; }
            set
            {
                this.listImage = value;
                this.tvMain.ImageList = this.listImage;
            }
        }
        /// <summary>
        /// 往图片集合中添加图片；并返回 图片的索引值；
        /// </summary>
        public int AddImage(Image img)
        {
            this.listImage.Images.Add(img);
            return listImage.Images.Count - 1;
        }
        /// <summary>
        /// 往图片集合中添加图片；并返回 图片的索引值；
        /// </summary>
        public int AddImage(string imgFile)
        {
            this.listImage.Images.Add(Image.FromFile(imgFile));
            return listImage.Images.Count - 1;
        }
        #endregion

        public TreeNodeCollection Nodes
        {
            get { return this.tvMain.Nodes; }
        }

        public TreeNode SelectedNode
        {
            get { return this.tvMain.SelectedNode; }
            set { this.tvMain.SelectedNode = value; }
        }

        /// <summary>
        /// 当前控件的树；
        /// </summary>
        public TreeView TreeViewMain
        {
            get { return this.tvMain; }
            set { this.tvMain = value; }
        } 
        #endregion

        public DBTree()
        {
            InitializeComponent();
            this.tvMain.Nodes.Clear();
        }
         
        public DbTreeNode GetNodeAt(Point point)
        {
            TreeNode node = this.tvMain.GetNodeAt(point);
            if (node == null)
            {
                node = this.tvMain.GetNodeAt(this.tvMain.PointToClient(point));
            }
            return node as DbTreeNode;
        }

        //private void tvMainNodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    DbTreeNode node = tvMain.SelectedNode as DbTreeNode;
        //    if (node != null && node.Tag is DBObjectSchema && OnNodeSelect != null)
        //        OnNodeClick.Invoke(node, e, (node.Tag) as DBObjectSchema);
        //}

        private void tvMainAfterSelect(object sender, TreeViewEventArgs e)
        {
            DbTreeNode node = tvMain.SelectedNode as DbTreeNode;
            if (node != null && node.Tag is DBObjectSchema && OnNodeSelect != null)
                OnNodeSelect.Invoke(node, e, (node.Tag) as DBObjectSchema);
        }

        private void tvMainMouseUp(object sender, MouseEventArgs e)
        {

        }

        private void tvMainMouseDown(object sender, MouseEventArgs e)
        {
            DbTreeNode nowNode = GetNodeAt(e.Location);
            if (nowNode != null)
            {
                if (e.Button == MouseButtons.Right)
                { 
                      nowNode.ContextMenuStrip = nowNode.GetContextMenuStrip();
                }
                tvMain.SelectedNode = nowNode;
            }
        }

        private void tvMain_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (AfterLabelEdit == null) return;
            AfterLabelEdit(sender,e); 
        }

        #region 刷新当前节点
        public virtual void RefreshCurrentNode()
        {
            DbTreeNode currentNode = tvMain.SelectedNode as DbTreeNode;
            RefreshNode(currentNode);
        }

        private void RefreshNode(DbTreeNode treeNode)
        {
            if (treeNode != null)
            {
                bool isExpanded = treeNode.IsExpanded;
                tvMain.SuspendLayout();
                try
                {
                    treeNode.Collapse();
                    treeNode.Nodes.Clear();
                    treeNode.Nodes.Add(new TreeNode());
                }
                finally 
                {
                    tvMain.ResumeLayout();
                }

                if (isExpanded) treeNode.ExpandCurrentDbTreeNode();
            }
        }
        #endregion 
    }
}
