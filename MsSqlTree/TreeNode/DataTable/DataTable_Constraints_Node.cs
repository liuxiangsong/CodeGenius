using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;

namespace MsSqlTree.TreeNode.DataTable
{
    public class DataTable_Constraints_Node : DbFolderTreeNode
    {
        public DataTable_Constraints_Node()
        {
            Text = "约束";
        }

        protected override object InitExpandTreeNodeData()
        {
            TableSchema tableSchema = (TableSchema)CurrentObjectSchema;
            DataBaseSchema dataBaseSchema = (DataBaseSchema)ParentObjectSchema;
            ConstraintSchemaCollection listConstraint = SqlSchemaHelper.ReadConstraintSchema(DataEngineSchema.ConnectionString, dataBaseSchema.Name, tableSchema.Name, tableSchema.Schema);
            ConstraintSchemaCollection listDefaultConstraint = SqlSchemaHelper.ReadDefaultConstraintSchema(DataEngineSchema.ConnectionString, dataBaseSchema.Name, tableSchema.Name, tableSchema.Schema);
            return new ConstraintSchemaCollection[] {listConstraint, listDefaultConstraint};
        }

        protected override void ExpandTreeNode(object parameters)
        {
            Nodes.Clear();

            ConstraintSchemaCollection[] arrayConstraint = (ConstraintSchemaCollection[]) parameters;
            ConstraintSchemaCollection listConstraint = arrayConstraint[0];
            ConstraintSchemaCollection listDefaultConstraint = arrayConstraint[1];

            if (listConstraint != null && listConstraint.Count > 0)
                foreach (ConstraintSchema item in listConstraint)
                    Nodes.Add(new DataTable_Constraint_Node(item) { Tag = item, CurrentObjectSchema = item });

            if (listDefaultConstraint != null && listDefaultConstraint.Count > 0)
                foreach (ConstraintSchema item in listDefaultConstraint)
                    Nodes.Add(new DataTable_Constraint_Node(item) { Tag = item, CurrentObjectSchema = item });
        }
    }
}
