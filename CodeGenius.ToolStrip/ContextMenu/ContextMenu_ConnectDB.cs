using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Frame.Interface;
using CodeGenius.Frame.Attributes;

namespace CodeGenius.ToolStrip.ContextMenu
{
    /// <summary>
    /// 连接数据库(&C)
    /// </summary>
     [MenuStrip(Key = "ContextMenu_ConnectDB", GroupKey = "ServerNode", ParentKey = "", GroupOrder = 9990, Order = 99900010, TrueType = typeof(ContextMenu_ConnectDB))]
    public class ContextMenu_ConnectDB : MenuStripItemBase
    {
        public override string Caption
        {
            get { return "连接(&C)"; }
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
                    SqlDBConnection.GetInstance().ShowDialog();
                };
            }
            set { }
        }
    }
}
