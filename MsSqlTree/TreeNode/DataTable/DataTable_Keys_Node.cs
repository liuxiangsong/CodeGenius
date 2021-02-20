using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;

namespace MsSqlTree.TreeNode.DataTable
{
  public  class DataTable_Keys_Node : DbFolderTreeNode
    {
      public DataTable_Keys_Node()
      {
          Text = "键";
      }

      protected override object InitExpandTreeNodeData()
      {
          TableSchema tableSchema = (TableSchema)CurrentObjectSchema;
          DataBaseSchema dataBaseSchema = (DataBaseSchema)ParentObjectSchema;
          KeySchemaCollection listPrimary = SqlSchemaHelper.ReadPrimaryKeySchema(DataEngineSchema.ConnectionString, dataBaseSchema.Name, tableSchema.Name);
          KeySchemaCollection listForeigne = SqlSchemaHelper.ReadForeigneKeySchema(DataEngineSchema.ConnectionString, dataBaseSchema.Name, tableSchema.Name);

          return new KeySchemaCollection[] { listPrimary, listForeigne };
      }

      protected override void ExpandTreeNode(object parameters)
      {
          Nodes.Clear();

          KeySchemaCollection[] arrayKey = (KeySchemaCollection[])parameters;
          KeySchemaCollection listPrimary = arrayKey[0];
          KeySchemaCollection listForeigne = arrayKey[1];

          if (listPrimary != null && listPrimary.Count > 0)
              foreach (KeySchema item in listPrimary)
                  Nodes.Add(new DataTable_Key_Node(item) { Tag = item, CurrentObjectSchema = item });

          if (listForeigne != null && listForeigne.Count > 0)
              foreach (KeySchema item in listForeigne)
                  Nodes.Add(new DataTable_Key_Node(item) { Tag = item, CurrentObjectSchema = item });
      }

    }
}
