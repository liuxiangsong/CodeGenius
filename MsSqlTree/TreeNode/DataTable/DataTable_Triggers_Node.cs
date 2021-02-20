using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;

namespace MsSqlTree.TreeNode.DataTable
{
   public class DataTable_Triggers_Node : DbFolderTreeNode
    {
       public DataTable_Triggers_Node()
        {
            Text = "触发器";
        }

        protected override object InitExpandTreeNodeData()
        {
            TableSchema tableSchema = (TableSchema)CurrentObjectSchema;
            DataBaseSchema dataBaseSchema = (DataBaseSchema)ParentObjectSchema;
            TriggerSchemaCollection list = SqlSchemaHelper.ReadTableTriggerSchema(DataEngineSchema.ConnectionString, dataBaseSchema.Name, tableSchema.Name, tableSchema.Schema );
            return list;
        }

        protected override void ExpandTreeNode(object parameters)
        {
            Nodes.Clear();

            TriggerSchemaCollection list = parameters as TriggerSchemaCollection;
            if (list != null && list.Count > 0)
                foreach (TriggerSchema item in list)
                    Nodes.Add(new DataTable_Trigger_Node(item) { Tag = item, CurrentObjectSchema = item });
        }
    }
}
