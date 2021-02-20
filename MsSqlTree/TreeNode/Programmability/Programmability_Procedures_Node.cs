using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;

namespace MsSqlTree.TreeNode.Programmability
{
    public class Programmability_Procedures_Node : DbFolderTreeNode
    {
        public Programmability_Procedures_Node()
        {
            Text = "存储过程";
        }

        protected override object InitExpandTreeNodeData()
        {
            DataBaseSchema dataBaseSchema = (DataBaseSchema)CurrentObjectSchema;
            ProcedureSchemaCollection list = SqlSchemaHelper.ReadProcedureSchema(DataEngineSchema.ConnectionString, dataBaseSchema.Name);
            return list;
        }

        protected override void ExpandTreeNode(object parameters)
        {
            Nodes.Clear();
            Nodes.Add(new Programmability_SystemProcedures_Node());

            ProcedureSchemaCollection list = parameters as ProcedureSchemaCollection;
            if (list != null && list.Count > 0)
                foreach (ProcedureSchema item in list)
                    Nodes.Add(new Programmability_Procedure_Node(item) { Tag = item, CurrentObjectSchema = item });
        }
    }
}
