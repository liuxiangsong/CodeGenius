using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using MsSqlTree.TreeNode.Programmability;

namespace MsSqlTree.TreeNode.DataBase
{
    public class DataBase_Programmability_Node : DbFolderTreeNode
    {
        public DataBase_Programmability_Node()
        {
            Text = "可编程性";
        }

        protected override void ExpandTreeNode(object parameters)
        {
            Nodes.Clear();
            Nodes.Add(new Programmability_Procedures_Node());
            //Nodes.Add(new DataBase_可编程性_函数_Node());
            //Nodes.Add(new DataBase_可编程性_数据库触发器_Node());
        }
    }
}
