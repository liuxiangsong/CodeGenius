using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;
using MsSqlTree.TreeNode.DataView;

namespace MsSqlTree.TreeNode.DataBase
{
   public class DataBase_DataView_Node : DbTreeNode
    {
       public DataBase_DataView_Node()
        {
            ImageKey = SelectedImageKey = "SqlClient_DataView";
        }

       public DataBase_DataView_Node(ViewSchema viewSchema): this()
       {
           Text = viewSchema.Schema + "." + viewSchema.Name;
       }

       protected override void ExpandTreeNode(object parameters)
       {
           Nodes.Clear();
           Nodes.Add(new DataView_Columns_Node());
           Nodes.Add(new DataView_Triggers_Node());
           Nodes.Add(new DataView_Indexs_Node());
       }
    }
}
