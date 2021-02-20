using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CodeGenius.Entity
{
    [Serializable]
    public class IndexSchema : DBObjectSchema
    {
        [Description("是否聚集")]
        public bool IsClustered { get; set; }

        [Description("是否唯一")]
        public bool IsUnique { get; set; }

        public override string ToString()
        {
            return Name + "(" +
                   (IsUnique ? "唯一, " : "不唯一, ") +
                   (IsClustered ? "聚集" : "非聚集")
                   + ")";
        }
    }

    [Serializable]
    public class IndexSchemaCollection : List<IndexSchema>
    {
    }
}
