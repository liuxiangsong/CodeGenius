using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.Interface;
using CodeGenius.Frame.Attributes;
using CodeGenius.Frame.TreeNodeBase;

namespace CodeGenius.ToolStrip.ContextMenu
{
    [MenuStrip(Key = "ContextMenuGroup_CURD", GroupKey = "GroupOfCURD", ParentKey = "", GroupOrder = 9990, Order = 99900010, TrueType = typeof(ContextMenuGroup_CURD))]
    public class ContextMenuGroup_CURD : MenuStripItemBase
    {
        public override string Caption
        {
            get { return "生成语句"; }
        }

        public override bool Enable(Frame.TreeNodeBase.DbTreeNode node)
        {
            return (node != null && node.nodeType == TreeNodeType.TableNode || node.nodeType == TreeNodeType.ViewNode);
        }

        public override bool Visible(Frame.TreeNodeBase.DbTreeNode node)
        {
            return this.Enable(node);
        }

        public override MenuStripHandler MenuStripHandler
        {
            get
            {
                return null ;
            }
            set
            {
                 
            }
        }
    }
}
