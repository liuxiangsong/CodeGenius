using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;

namespace MsSqlTree.TreeNode.DataEngine
{
    public class DataBases_Node : DbFolderTreeNode
    {
        public DataBases_Node()
        {
            Text = "数据库";
            this.Expand();
        }

        protected override object InitExpandTreeNodeData()
        {
            DataBaseSchemaCollection list = SqlSchemaHelper.ReadDataBaseSchema(DataEngineSchema.ConnectionString);
            return list;
        }

        protected override void ExpandTreeNode(object parameters)
        {
            Nodes.Clear();
            Nodes.Add(new SystemDataBases_Node()); 

            DataBaseSchemaCollection list = parameters as DataBaseSchemaCollection;
            if (list != null && list.Count > 0)
            {
                foreach (DataBaseSchema item in list)
                {
                    Nodes.Add(new DataBase_Node(item) { Tag = item, CurrentObjectSchema = item });
                }
            }
        }
    }
}
