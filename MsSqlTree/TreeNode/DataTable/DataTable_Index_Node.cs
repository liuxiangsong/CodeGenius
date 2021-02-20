using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;

namespace MsSqlTree.TreeNode.DataTable
{
    public class DataTable_Index_Node : DbTreeNode
    {
         public DataTable_Index_Node()
        {
            Nodes.Clear();
           
        }
         public DataTable_Index_Node(IndexSchema indexSchema)
             : this()
        {
            Text = indexSchema.ToString();
            if (indexSchema.IsClustered)
                ImageKey = SelectedImageKey = "SqlClient_DataIsClusteredIndex";
            else
                ImageKey = SelectedImageKey = "SqlClient_DataIndex";
        }
 
    }
}
