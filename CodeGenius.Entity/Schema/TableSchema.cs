using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CodeGenius.Entity
{
    [Serializable]
    public class TableSchema : DBObjectSchema
    {
         [Description("Schema")]
        public string Schema { get; set; }

        [Description("创建时间")]
         public DateTime CreateDate { get; set; }

        [Description("修改时间")]
         public DateTime ModifyDate { get; set; }

        [Description("表列集合")]
        public ColumnSchemaCollection Columns { get; set; }

        [Description("表主键集合")]
        public ColumnSchemaCollection PrimaryColumns
        {
            get
            {
                ColumnSchemaCollection collection = new ColumnSchemaCollection();
                foreach (ColumnSchema columnSchema in Columns)
                    if (columnSchema.IsPrimaryKey) collection.Add(columnSchema);
                return collection;
            }
        }

        [Description("表自增长列")]
        public ColumnSchema IdentityColumn
        {
            get
            {
                foreach (ColumnSchema columnSchema in Columns)
                    if (columnSchema.IsIdentity) return columnSchema;
                return null;
            }
        }

    }

    [Serializable]
    public class TableSchemaCollection : List<TableSchema>
    {
    }
}
