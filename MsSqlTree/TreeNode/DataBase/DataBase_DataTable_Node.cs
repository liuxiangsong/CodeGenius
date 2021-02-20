using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;
using MsSqlTree.TreeNode.DataTable;

namespace MsSqlTree.TreeNode.DataBase
{
    public class DataBase_DataTable_Node : DbTreeNode 
    {
        
        public DataBase_DataTable_Node()
        {
            nodeType = TreeNodeType.TableNode; 
            ImageKey = SelectedImageKey = "SqlClient_DataTable";
        }

        public DataBase_DataTable_Node(TableSchema tableSchema): this()
        {
            Text = tableSchema.Schema + "." + tableSchema.Name;
        }

        protected override void ExpandTreeNode(object parameters)
        {
            Nodes.Clear();
            Nodes.Add(new DataTable_Columns_Node());
            Nodes.Add(new DataTable_Keys_Node());
            Nodes.Add(new DataTable_Constraints_Node());
            Nodes.Add(new DataTable_Triggers_Node());
            Nodes.Add(new DataTable_Indexs_Node());
        }
    }
}
