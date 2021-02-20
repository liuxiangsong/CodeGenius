using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;

namespace MsSqlTree.TreeNode.DataBase
{
    public class DataBase_SystemViews_Node : DbFolderTreeNode
    {
        public DataBase_SystemViews_Node()
        {
            Text = "系统视图";
        }

        protected override object InitExpandTreeNodeData()
        {
            DataBaseSchema dataBaseSchema = (DataBaseSchema)CurrentObjectSchema;
            ViewSchemaCollection list = SqlSchemaHelper.ReadSysViewSchema(DataEngineSchema.ConnectionString, dataBaseSchema.Name);
            return list;
        }

        protected override void ExpandTreeNode(object parameters)
        {
            Nodes.Clear();

            ViewSchemaCollection list = parameters as ViewSchemaCollection;
            if (list != null && list.Count > 0)
                foreach (ViewSchema item in list)
                    Nodes.Add(new DataBase_DataView_Node(item) { Tag = item, CurrentObjectSchema = item });
        }

    }
}
