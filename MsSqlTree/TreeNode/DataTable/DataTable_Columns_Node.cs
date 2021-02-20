using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;

namespace MsSqlTree.TreeNode.DataTable
{
    public class DataTable_Columns_Node : DbFolderTreeNode
    {
       public DataTable_Columns_Node()
       {
           Text = "列";
       }

       protected override object InitExpandTreeNodeData()
       {
           TableSchema tableSchema = (TableSchema)CurrentObjectSchema;
           DataBaseSchema dataBaseSchema = (DataBaseSchema)ParentObjectSchema;
           ColumnSchemaCollection list = SqlSchemaHelper.ReadTableColumnSchema(DataEngineSchema.ConnectionString, dataBaseSchema.Name, tableSchema.Name, tableSchema.Schema);
           return list;
       }

       protected override void ExpandTreeNode(object parameters)
       {
           Nodes.Clear();

           ColumnSchemaCollection list = parameters as ColumnSchemaCollection;
           if (list != null && list.Count > 0)
           {
               foreach (ColumnSchema item in list)
               {
                   Nodes.Add(new DataTable_Column_Node(item) { Tag = item, CurrentObjectSchema = item });
               }
           }
       }
    }
}
