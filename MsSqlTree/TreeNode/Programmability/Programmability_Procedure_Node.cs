using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;

namespace MsSqlTree.TreeNode.Programmability
{
    public class Programmability_Procedure_Node : DbTreeNode
    {
          public Programmability_Procedure_Node()
        {
            ImageKey = SelectedImageKey = "SqlClient_DataProcedure";
        }
          public Programmability_Procedure_Node(ProcedureSchema procedureSchema)
              : this()
        {
            Text = procedureSchema.Schema + "." + procedureSchema.Name;
        }

        protected override void ExpandTreeNode(object parameters) 
        {
            Nodes.Clear();
            Nodes.Add(new Programmability_Parameters_Node());
        }
    }
}
