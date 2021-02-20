using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;
using LibraryGenius;

namespace MsSqlTree.TreeNode.DataTable
{
    public class DataTable_Column_Node : DbTreeNode
    {
        public DataTable_Column_Node()
        {
            Nodes.Clear();
        }

        public DataTable_Column_Node(ColumnSchema columnSchema): this()
        {
            Text=string.Format("{0} ({1}{2},{3})",
                                columnSchema.Name,
                                columnSchema.IsPrimaryKey?"PK,":string.Empty,
                                columnSchema.FullDataType,
                                columnSchema.IsNullable?"null":"not null");

            if ( columnSchema.IsPrimaryKey)
                ImageKey = SelectedImageKey = "SqlClient_DataPrimary";
            else if (TypeHelper.ToBoolean(columnSchema.IsForeignKey))
                ImageKey = SelectedImageKey = "SqlClient_DataForeigne";
            else
                ImageKey = SelectedImageKey = "SqlClient_DataField";
        }
    }
}
