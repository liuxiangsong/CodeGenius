using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;

namespace MsSqlTree.TreeNode.DataEngine
{
    public class SystemDataBases_Node : DbFolderTreeNode
    {
        public SystemDataBases_Node()
        {
            Text = "系统数据库";
        }

        protected override object InitExpandTreeNodeData()
        {
            DataBaseSchemaCollection list = SqlSchemaHelper.ReadSysDataBaseSchema(DataEngineSchema.ConnectionString);
            return list;
        }

        protected override void ExpandTreeNode(object parameters)
        {
            Nodes.Clear();
            DataBaseSchemaCollection list = parameters as DataBaseSchemaCollection;
            if (list != null && list.Count > 0)
                foreach (DataBaseSchema item in list)
                    Nodes.Add(new DataBase_Node(item) { Tag = item, CurrentObjectSchema = item });
        }
    }
}
