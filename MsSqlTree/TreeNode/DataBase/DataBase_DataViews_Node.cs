using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using CodeGenius.Entity;
using CodeGenius.Frame.TreeNodeBase;

namespace MsSqlTree.TreeNode.DataBase
{
    public class DataBase_DataViews_Node : DbFolderTreeNode
    {
        public DataBase_DataViews_Node()
        {
            Text = "视图";
        }

        protected override object InitExpandTreeNodeData()
        {
            DataBaseSchema dataBaseSchema = (DataBaseSchema)CurrentObjectSchema;
            ViewSchemaCollection list = SqlSchemaHelper.ReadViewSchema(DataEngineSchema.ConnectionString, dataBaseSchema.Name);
            return list;
        }

        protected override void ExpandTreeNode(object parameters)
        {
            Nodes.Clear();
            Nodes.Add(new DataBase_SystemViews_Node());

            ViewSchemaCollection list = parameters as ViewSchemaCollection;
            if (list != null && list.Count > 0)
                foreach (ViewSchema item in list)
                    Nodes.Add(new DataBase_DataView_Node(item) { Tag = item, CurrentObjectSchema = item });
        }
    }
}
