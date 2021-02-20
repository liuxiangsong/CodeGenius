using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.Interface;
using System.Drawing;
using CodeGenius.Frame.Attributes;
using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.frm;
using CodeGenius.Entity;

namespace CodeGenius.ToolStrip.ContextMenu
{
    [MenuStrip(Key = "ContextMenu_GenerateDeleteStatement", GroupKey = "GroupOfCURD", ParentKey = "ContextMenuGroup_CURD", GroupOrder = 9990, Order = 99900010, TrueType = typeof(ContextMenu_GenerateDeleteStatement))]
    public class ContextMenu_GenerateDeleteStatement : MenuStripItemBase
    {
        public override string Caption
        {
            get { return "DELETE(&L)"; }
        }

        public override Image Image
        {
            get { return null; }
        }

        public override bool Enable(DbTreeNode node)
        {
            return (node != null && node.nodeType == TreeNodeType.TableNode || node.nodeType == TreeNodeType.ViewNode);
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
                    DbTreeNode selectedNode = MainFormDX.ucDBTree.SelectedNode as DbTreeNode;
                    if (selectedNode == null) return;

                    SqlDataEngineSchema engineSchema = selectedNode.AscendDbObjectSchema<SqlDataEngineSchema>();
                    DataBaseSchema dbSchema = selectedNode.AscendDbObjectSchema<DataBaseSchema>();
                    TableSchema tableSchema;
                    ViewSchema viewSchema; 

                    string sqlString = string.Empty;

                    if (selectedNode.nodeType == TreeNodeType.TableNode)
                    {
                        tableSchema = selectedNode.CurrentObjectSchema as TableSchema; 
                        sqlString = string.Format("DELETE FROM [{0}].[{1}].[{2}] \r\n\t  ", dbSchema.Name, tableSchema.Schema, tableSchema.Name);
                    }
                    else
                    {
                        viewSchema = selectedNode.CurrentObjectSchema as ViewSchema; 
                        sqlString = string.Format("DELETE FROM [{0}].[{1}].[{2}] \r\n\t  ", dbSchema.Name, viewSchema.Schema, viewSchema.Name);
                    }
                    sqlString = sqlString + "WHERE";
                    QueryForm.NewQueryForm( sqlString, engineSchema, dbSchema);
                };
            }
            set { }
        }
    }
}
