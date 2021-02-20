using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.Attributes;
using CodeGenius.Frame.Interface;
using System.Drawing;
using CodeGenius.Frame.TreeNodeBase;

namespace CodeGenius.ContextMenu
{
     [MenuStrip(Key = "ContextMenu_RefreshNode", GroupKey = "Last", ParentKey = "", GroupOrder = 9990, Order = 99900010, TrueType = typeof(ContextMenu_RefreshNode))]
    public class ContextMenu_RefreshNode : MenuStripItemBase
    {       
        public override string Caption
        {
            get { return "刷新(&F)"; }
        }

        public override Image Image
        {
            get { return GetStripImage("/Images/ContextMenuImages/ContextMenu_OpenTable.png"); }
        }

        public override bool Enable(DbTreeNode node)
        { 
            return (node != null ); 
        }

        public override bool Visible(DbTreeNode node)
        {
            return (node != null );
        }
        public override MenuStripHandler MenuStripHandler
        {
            get 
            {
                return delegate(object sender, EventArgs e)
                {
                   MainFormDX.ucDBTree.RefreshCurrentNode(); 
                };
            }
            set { }
        }
    }
}
