using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;

namespace MsSqlTree.TreeNode.DataTable
{
    public class DataTable_Trigger_Node : DbTreeNode
    {
         public DataTable_Trigger_Node()
        {
            Nodes.Clear();
        }
         public DataTable_Trigger_Node(TriggerSchema triggerSchema)
             : this()
        {
            Text = triggerSchema.ToString();
            ImageKey = SelectedImageKey = "SqlClient_DataTrigger";
        }
 
    }
}
