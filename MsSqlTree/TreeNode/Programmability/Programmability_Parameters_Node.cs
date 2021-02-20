using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;

namespace MsSqlTree.TreeNode.Programmability
{
    public class Programmability_Parameters_Node : DbFolderTreeNode
    {
        public Programmability_Parameters_Node()
        {
            Text = "参数";
        }

        protected override object InitExpandTreeNodeData()
        {
            DataBaseSchema dataBaseSchema = (DataBaseSchema)ParentObjectSchema;
            ProcedureSchema procedureSchema = (ProcedureSchema)CurrentObjectSchema;
            ParameterSchemaCollection list = SqlSchemaHelper.ReadProcedureParameterSchema(DataEngineSchema.ConnectionString, dataBaseSchema.Name, procedureSchema.Name);
            return list;
        }

        protected override void ExpandTreeNode(object parameters)
        {
            Nodes.Clear();

            ParameterSchemaCollection list = parameters as ParameterSchemaCollection;
            if (list != null && list.Count > 0)
                foreach (ParameterSchema item in list)
                    Nodes.Add(new Programmability_Parameter_Node(item) { Tag = item, CurrentObjectSchema = item });
        }
    }
}
