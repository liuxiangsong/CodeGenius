using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;
using MsSqlTree.TreeNode.DataBase;

namespace MsSqlTree.TreeNode.DataEngine
{
   public class DataBase_Node : DbTreeNode
    {
        public DataBase_Node()
        {
            ImageKey = SelectedImageKey = "SqlClient_DataBase";
        }
        public DataBase_Node(DataBaseSchema dataBase) : this()
        {
            Text = dataBase.Name;
        }

        protected override void ExpandTreeNode(object parameters)
        {
            Nodes.Clear();
            Nodes.Add(new DataBase_DataTables_Node());
            Nodes.Add(new DataBase_DataViews_Node());
            Nodes.Add(new DataBase_Programmability_Node());
        }
    }
}
