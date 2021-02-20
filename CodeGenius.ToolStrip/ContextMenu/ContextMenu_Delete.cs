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
    [MenuStrip(Key = "ContextMenu_Delete", GroupKey = "TableNode", ParentKey = "", GroupOrder = 9990, Order = 99900010, TrueType = typeof(ContextMenu_Delete))]
    public class ContextMenu_Delete : MenuStripItemBase
    {
        private DbTreeNode selectedNode;
        private TableSchema tableSchema;

        public override string Caption
        {
            get { return "删除(&D)"; }
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
                    selectedNode = MainFormDX.ucDBTree.SelectedNode as DbTreeNode;
                    if (selectedNode == null) return;
                    DataBaseSchema dbSchem = selectedNode.AscendDbObjectSchema<DataBaseSchema>();
                    tableSchema = selectedNode.AscendDbObjectSchema<TableSchema>();

                    string strSQL = string.Empty;
                    if (selectedNode.GetType() == typeof(DataBaseSchema))
                    {
                        strSQL = string.Format("Use [master] drop database [{0}]", dbSchem.Name);
                    }
                    else if (selectedNode.GetType() == typeof(TableSchema))
                    {
                        strSQL = string.Format("Use [{0}] drop table [{1}].[{2}]", dbSchem.Name, tableSchema.Schema, tableSchema.Name);
                    }
                    else if (selectedNode.GetType() == typeof(ColumnSchema))
                    {
                        strSQL = string.Format("Use [{0}] alter table [{1}].[{2}] drop column [{3}]",
                            dbSchem.Name, tableSchema.Schema, tableSchema.Name, selectedNode.Name);
                    }
                    else if (selectedNode.GetType() == typeof(ProcedureSchema))
                    {
                        ProcedureSchema procSchema = selectedNode.AscendDbObjectSchema<ProcedureSchema>();
                        strSQL = string.Format("Use [{0}] drop procedure [{1}].[{2}]", dbSchem.Name, procSchema.Schema, procSchema.Name);
                    }
                    else if (selectedNode.GetType() == typeof(ViewSchema))
                    {
                        ViewSchema viewSchema = selectedNode.AscendDbObjectSchema<ViewSchema>();
                        strSQL = string.Format("Use [{0}] drop view [{1}].[{2}]", dbSchem.Name, viewSchema.Schema, viewSchema.Name);
                    }

                    DBHelper.SqlHelper.SqlConnectionString = dbSchem.ConnectionString;
                    string message="是否确认删除"+selectedNode.Parent.Text+"["+selectedNode.Text+"]?";
                    if (MsgBox.ConfirmYesNo(message))
                    {
                        DBHelper.SqlHelper.ExecuteNonQuery(strSQL);
                        selectedNode.Remove();
                    }
                };
            }
            set { }
        }

    }
}
