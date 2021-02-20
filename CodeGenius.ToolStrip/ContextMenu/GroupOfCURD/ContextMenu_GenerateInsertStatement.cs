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
    [MenuStrip(Key = "ContextMenu_GenerateInsertStatement", GroupKey = "GroupOfCURD", ParentKey = "ContextMenuGroup_CURD", GroupOrder = 9990, Order = 99900010, TrueType = typeof(ContextMenu_GenerateInsertStatement))]
    public class ContextMenu_GenerateInsertStatement : MenuStripItemBase
    {
        public override string Caption
        {
            get { return "INSERT(&I)"; }
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
                    ColumnSchemaCollection columns;

                    string sqlString = string.Empty;

                    if (selectedNode.nodeType == TreeNodeType.TableNode)
                    {
                        tableSchema = selectedNode.CurrentObjectSchema as TableSchema;
                        columns = tableSchema.Columns;
                        sqlString = string.Format(" INSERT INTO [{0}].[{1}].[{2}] \r\n", dbSchema.Name, tableSchema.Schema, tableSchema.Name);
                    }
                    else
                    {
                        viewSchema = selectedNode.CurrentObjectSchema as ViewSchema;
                        columns = viewSchema.Columns;
                        sqlString = string.Format(" INSERT INTO [{0}].[{1}].[{2}] \r\n", dbSchema.Name, viewSchema.Schema, viewSchema.Name);
                    }

                    StringBuilder sbColumns = new StringBuilder();
                    StringBuilder sbValues = new StringBuilder();
                    foreach (ColumnSchema columnSchema in columns)
                    {
                        sbColumns.AppendLine(string.Format("\t\t\t,[{0}]", columnSchema.Name));
                        sbValues.AppendLine(string.Format("\t\t\t,@{0}", columnSchema.Name));
                    }

                    sbColumns = sbColumns.Remove(3, 1).Insert(3,"(").Insert(0, sqlString)
                        .Insert(sbColumns.Length-2,")").AppendLine("\t  VALUES");
                    sbValues = sbValues.Remove(3, 1).Insert(3, "(").Insert(sbValues.Length - 2, ")");
                    sqlString = sbColumns.AppendLine(sbValues.ToString()).ToString();
                    QueryForm.NewQueryForm(sqlString, engineSchema, dbSchema);
                };
            }
            set { }
        }
    }
}
