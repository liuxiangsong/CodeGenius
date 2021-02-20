using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;

namespace MsSqlTree.TreeNode.DataTable
{
    public class DataTable_Indexs_Node : DbFolderTreeNode
    {
        public DataTable_Indexs_Node()
        {
            Text = "索引";
        }

        protected override object InitExpandTreeNodeData()
        {
            TableSchema tableSchema = (TableSchema)CurrentObjectSchema;
            DataBaseSchema dataBaseSchema = (DataBaseSchema)ParentObjectSchema;
            IndexSchemaCollection list = SqlSchemaHelper.ReadTableIndexSchema(DataEngineSchema.ConnectionString, dataBaseSchema.Name, tableSchema.Name, tableSchema. Schema );

            return list;
        }

        protected override void ExpandTreeNode(object parameters)
        {
            Nodes.Clear();

            IndexSchemaCollection list = parameters as IndexSchemaCollection;

            if (list != null && list.Count > 0)
                foreach (IndexSchema item in list)
                    Nodes.Add(new DataTable_Index_Node(item) { Tag = item, CurrentObjectSchema = item });
        }
    }
}
