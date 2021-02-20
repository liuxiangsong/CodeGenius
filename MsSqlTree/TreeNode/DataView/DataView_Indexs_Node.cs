using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;
using MsSqlTree.TreeNode.DataTable;

namespace MsSqlTree.TreeNode.DataView
{
  public  class DataView_Indexs_Node : DbFolderTreeNode
    {
      public DataView_Indexs_Node()
        {
            Text = "索引";
        }

      protected override object InitExpandTreeNodeData()
        {
            ViewSchema viewSchema = (ViewSchema)CurrentObjectSchema;
            DataBaseSchema dataBaseSchema = (DataBaseSchema)ParentObjectSchema;
            IndexSchemaCollection list = SqlSchemaHelper.ReadTableIndexSchema(DataEngineSchema.ConnectionString, dataBaseSchema.Name, viewSchema.Name, viewSchema.Schema);

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
