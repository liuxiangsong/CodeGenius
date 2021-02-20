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
    [MenuStrip(Key = "ContextMenu_GenerateSelectStatement", GroupKey = "GroupOfCURD", ParentKey = "ContextMenuGroup_CURD", GroupOrder = 9990, Order = 99900010, TrueType = typeof(ContextMenu_GenerateSelectStatement))]
    public class ContextMenu_GenerateSelectStatement : MenuStripItemBase
    {
        public override string Caption
        {
            get { return "SELECT(&S)"; }
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
                        sqlString = string.Format("    FROM [{0}].[{1}].[{2}] ", dbSchema.Name, tableSchema.Schema, tableSchema.Name);
                    }
                    else
                    {
                        viewSchema = selectedNode.CurrentObjectSchema as ViewSchema;
                        columns = viewSchema.Columns;
                        sqlString = string.Format("    FROM [{0}].[{1}].[{2}] ", dbSchema.Name, viewSchema.Schema, viewSchema.Name);
                    }


                    StringBuilder sb = new StringBuilder();
                    foreach (ColumnSchema columnSchema in columns)
                    {
                        sb.AppendLine(string.Format("\t\t,[{0}]", columnSchema.Name));
                    }
                    sb.Insert(0, "  SELECT ");
                    sb.AppendLine(sqlString);

                    string strSQL = sb.ToString();
                    strSQL = strSQL.Remove(strSQL.IndexOf("\t\t,"), 3);
                    QueryForm.NewQueryForm( strSQL, engineSchema, dbSchema);
                };
            }
            set { }
        }
    }
}
