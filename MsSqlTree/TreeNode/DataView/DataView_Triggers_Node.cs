using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;
using MsSqlTree.TreeNode.DataTable;

namespace MsSqlTree.TreeNode.DataView
{
   public class DataView_Triggers_Node : DbFolderTreeNode
    {
       public DataView_Triggers_Node()
        {
            Text = "触发器";
        }

       protected override object InitExpandTreeNodeData()
        {
            ViewSchema viewSchema = (ViewSchema)CurrentObjectSchema;
            DataBaseSchema dataBaseSchema = (DataBaseSchema)ParentObjectSchema;
            TriggerSchemaCollection list = SqlSchemaHelper.ReadViewTriggerSchema(DataEngineSchema.ConnectionString, dataBaseSchema.Name, viewSchema.Name, viewSchema.Schema);
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
