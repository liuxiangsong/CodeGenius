using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeGenius.Frame.Interface;
using CodeGenius.Frame.Attributes;
using System.Drawing;
using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;

namespace CodeGenius.ToolStrip.ContextMenu
{
     [MenuStrip(Key = "ContextMenu_DisConnectDB", GroupKey = "ServerNode", ParentKey = "", GroupOrder = 9990, Order = 99900010, TrueType = typeof(ContextMenu_DisConnectDB))]
    public class ContextMenu_DisConnectDB : MenuStripItemBase
    {
        public override string Caption
        {
            get { return "断开连接(&D)"; }
        }

        public override Image Image
        {
            get { return null; }
        }

        public override bool Enable(DbTreeNode node)
        {
            return (node != null && node.nodeType == TreeNodeType.ServerNode);
        }

        public override bool Visible(DbTreeNode node)
        {
            return this.Enable(node);
        }
        public override MenuStripHandler MenuStripHandler
        {
            get
            {
                return delegate(object sender, EventArgs e)
                {
                    MainFormDX.ucDBTree.SelectedNode.Remove();  
                };
            }
            set { }
        }
    }
}
