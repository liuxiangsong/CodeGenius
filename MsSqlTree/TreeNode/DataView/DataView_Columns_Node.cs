using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;
using MsSqlTree.TreeNode.DataTable; 

namespace MsSqlTree.TreeNode.DataView
{
    public class DataView_Columns_Node : DbFolderTreeNode
    {
        public DataView_Columns_Node()
        {
            Text = "列";
        }

        protected override object InitExpandTreeNodeData()
        {
            ViewSchema viewSchema = (ViewSchema)CurrentObjectSchema;
            DataBaseSchema dataBaseSchema = (DataBaseSchema)ParentObjectSchema;
            ColumnSchemaCollection list = SqlSchemaHelper.ReadViewColumnSchema(DataEngineSchema.ConnectionString, dataBaseSchema.Name, viewSchema.Name,viewSchema.Schema);
            return list;
        }

        protected override void ExpandTreeNode(object parameters)
        {
            Nodes.Clear();

            ColumnSchemaCollection list = parameters as ColumnSchemaCollection;
            if (list != null && list.Count > 0)
                foreach (ColumnSchema item in list)
                    Nodes.Add(new DataTable_Column_Node(item) { Tag = item, CurrentObjectSchema = item });
        }

    }
}
