﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;

namespace MsSqlTree.TreeNode.DataBase
{
  public  class DataBase_SystemTables_Node : DbFolderTreeNode
    {
      public DataBase_SystemTables_Node()
      {
          Text = "系统表";
      }

      protected override object InitExpandTreeNodeData()
      {
          DataBaseSchema dataBaseSchema = (DataBaseSchema)CurrentObjectSchema;
          TableSchemaCollection list = SqlSchemaHelper.ReadSysTableSchema(DataEngineSchema.ConnectionString, dataBaseSchema.Name);
          return list;
      }

      protected override void ExpandTreeNode(object parameters)
      {
          Nodes.Clear();

          TableSchemaCollection list = parameters as TableSchemaCollection;
          if (list != null && list.Count > 0)
          {
              foreach (TableSchema item in list)
              {
                  Nodes.Add(new DataBase_DataTable_Node(item) { Tag = item, CurrentObjectSchema = item });
              }
          }
      }
    }
}
