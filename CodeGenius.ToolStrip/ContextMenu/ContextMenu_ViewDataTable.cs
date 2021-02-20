using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.Interface;
using CodeGenius.Frame.Attributes;
using CodeGenius.Frame.TreeNodeBase;

namespace CodeGenius.ToolStrip.ContextMenu
{
    [MenuStrip(Key = "ContextMenu_ViewDataTable", GroupKey = "", ParentKey = "", GroupOrder = 9990, Order = 99900010, TrueType = typeof(ContextMenu_ViewDataTable))]
    public class ContextMenu_ViewDataTable : MenuStripItemBase
    {
        public override string Caption
        {
            get { return "查看表数据(&V)"; }
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
                return delegate(object sender, EventArgs e)
                {
                    frmViewTableData frm = frmViewTableData.Instance;
                    frm.MdiParent = MainFormDX.Instance;
                    frm.Show();
                    frm.Activate();
                };
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
