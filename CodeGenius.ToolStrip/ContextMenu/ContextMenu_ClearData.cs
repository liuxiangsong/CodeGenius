using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.Interface;
using System.Drawing;
using CodeGenius.Frame.Attributes;
using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;
using LibraryGenius;

namespace CodeGenius.ToolStrip.ContextMenu
{
    /// <summary>
    /// 清除表数据(&L)
    /// </summary>
    [MenuStrip(Key = "ContextMenu_ClearData", GroupKey = "Last", ParentKey = "", GroupOrder = 9990, Order = 99900010, TrueType = typeof(ContextMenu_ClearData))]
    public class ContextMenu_ClearData : MenuStripItemBase
    {
        public override string Caption
        {
            get { return "清除表数据(&L)"; }
        }

        public override Image Image
        {
            get { return null; }
        }

        public override bool Enable(DbTreeNode node)
        {
            return (node != null && node.nodeType == TreeNodeType.TableNode);
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
                    DataBaseSchema dbSchem = selectedNode.AscendDbObjectSchema<DataBaseSchema>();
                    TableSchema tableSchema = selectedNode.AscendDbObjectSchema<TableSchema>();

                    string strSQL = string.Format("Use [{0}] Truncate Table [{1}].[{2}]", dbSchem.Name, tableSchema.Schema, tableSchema.Name);

                    DBHelper.SqlHelper.SqlConnectionString = dbSchem.ConnectionString;
                    string message = "是否确认清除[" + selectedNode.Text + "]表中的数据?";
                    if (MsgBox.ConfirmYesNo(message))
                    {
                        try
                        {
                            DBHelper.SqlHelper.ExecuteNonQuery(strSQL);
                        }
                        catch
                        {
                            strSQL = string.Format("Use [{0}] delete [{1}].[{2}]", dbSchem.Name, tableSchema.Schema, tableSchema.Name);
                            DBHelper.SqlHelper.ExecuteNonQuery(strSQL);
                        }
                        MsgBox.ShowInformation("清除成功");
                    }
                };
            }
            set { }
        }
    }
}
