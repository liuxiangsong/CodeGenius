using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;

namespace MsSqlTree.TreeNode.DataTable
{
    public class DataTable_Constraint_Node : DbTreeNode
    {
        public DataTable_Constraint_Node()
        {
            Nodes.Clear();
            ImageKey = SelectedImageKey = "SqlClient_DataConstraint";
        }
        public DataTable_Constraint_Node(ConstraintSchema constraintSchema)
            : this()
        {
            Text = constraintSchema.Name;
            //if (constraintSchema.IsDefault))
            //    ImageKey = SelectedImageKey = "SqlClient_DataDefaultConstraint";
            //else
                ImageKey = SelectedImageKey = "SqlClient_DataConstraint";
        }

        protected override void OnBeforeExpandHandler(DbTreeNode parentnode)
        {
        
        }
    }
}
