using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.Interface;
using CodeGenius.Frame.Attributes;
using System.Drawing;
using CodeGenius.Frame.TreeNodeBase;
using System.Windows.Forms;
using CodeGenius.Entity;
using LibraryGenius;

namespace CodeGenius.ToolStrip.ContextMenu
{
    [MenuStrip(Key = "ContextMenu_Rename", GroupKey = "Last", ParentKey = "", GroupOrder = 9990, Order = 99900010, TrueType = typeof(ContextMenu_Rename))]
    public class ContextMenu_Rename : MenuStripItemBase
    {
        private DbTreeNode selectedNode;
        private TableSchema tableSchema;

        public override string Caption
        {
            get { return "重命名(&R)"; }
        }

        public override Image Image
        {
            get { return null; }
        }

        public override bool Enable(DbTreeNode node)
        {
            return (node != null && (node.nodeType == TreeNodeType.DatabaseNode
                || node.nodeType == TreeNodeType.TableNode || node.nodeType == TreeNodeType.ColumnNode
                || node.nodeType == TreeNodeType.ProcdureNode || node.nodeType == TreeNodeType.ViewNode));
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
                    MainFormDX.ucDBTree.TreeViewMain.LabelEdit = true;
                    selectedNode = MainFormDX.ucDBTree.SelectedNode as DbTreeNode;
                    if (selectedNode == null) return;

                    tableSchema = selectedNode.AscendDbObjectSchema<TableSchema>();
                    selectedNode.Text = selectedNode.Text.Remove(0, selectedNode.Text.IndexOf(tableSchema.Name));
                    selectedNode.BeginEdit();
                    MainFormDX.ucDBTree.AfterLabelEdit += new NodeLabelEditEventHandler(Rename);
                };
            }
            set { }
        }

        private void Rename(object sender, NodeLabelEditEventArgs e)
        {
            string objType = string.Empty;
            string oldName = string.Empty;

            if (selectedNode == null) return;

            if (selectedNode.GetType() == typeof(DataBaseSchema))
            {
                objType = "database";
            }
            else if (selectedNode.GetType() == typeof(ColumnSchema))
            {
                objType = "column";
                oldName = string.Format("[{0}].[{1}].[{2}]", tableSchema.Schema, tableSchema.Name, e.Node.Text);
            }
            else
            {
                oldName = string.Format("[{0}].[{1}]", tableSchema.Schema, e.Node.Text);
            }

            DataBaseSchema dbSchem = selectedNode.AscendDbObjectSchema<DataBaseSchema>();

            if (!string.IsNullOrEmpty(e.Label))
            {
                DBHelper.SqlHelper.SqlConnectionString = dbSchem.ConnectionString;
                DBHelper.SqlUtil.DBObjectRename(dbSchem.Name, oldName, e.Label, objType);
                selectedNode.Text = string.Format("{0}.{1}", tableSchema.Schema, e.Label);
            }

            MainFormDX.ucDBTree.AfterLabelEdit -= new NodeLabelEditEventHandler(Rename);
            MainFormDX.ucDBTree.TreeViewMain.LabelEdit = false;
            selectedNode.Text = string.Format("{0}.{1}", tableSchema.Schema, e.Node.Text);
        }
    }
}
