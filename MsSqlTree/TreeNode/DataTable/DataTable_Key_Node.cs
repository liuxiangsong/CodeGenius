using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;
using LibraryGenius;

namespace MsSqlTree.TreeNode.DataTable
{
    public class DataTable_Key_Node : DbTreeNode
    {
        public DataTable_Key_Node()
        {
            Nodes.Clear();
        }

        public DataTable_Key_Node(KeySchema keySchema) : this()
        {
            Text = keySchema.Name;

            if (keySchema.KeyType == KeyType.Primary)
                ImageKey = SelectedImageKey = "SqlClient_DataPrimary";
            else if (keySchema.KeyType == KeyType.Foreigne)
                ImageKey = SelectedImageKey = "SqlClient_DataForeigne";
        }
    }
}
