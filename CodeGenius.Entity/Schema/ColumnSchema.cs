using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CodeGenius.Entity
{
    [Serializable]
    public class ColumnSchema : DBObjectSchema
    {
        [Description("ID of the object to which this column belongs")]
        public int ObjectID { get; set; }

        [Description("列序号")]
        public int ColumnID { get; set; }

        [Description("字段类型")]
        public string DataType { get; set; }

        [Description("最大长度")]
        public Int16 MaxLength { get; set; }

        [Description("小数位数")]
        public Int16 Scale { get; set; }

        [Description("是否是自增长列")]
        public bool IsIdentity { get; set; }

        [Description("是否是主键")]
        public bool IsPrimaryKey { get; set; }

        [Description("是否允许为空")]
        public bool IsNullable { get; set; }

        [Description("默认值")]
        public string DefaultValue { get; set; }

        [Description("列说明")]
        public string Description { get; set; }

        [Description("排序规则")]
        public string CollationName { get; set; }

        [Description("是否是外键")]
        public bool IsForeignKey { get; set; }

        [Description("数据明细类型，如：decimal(18,4)")]
        public string FullDataType { get; set; }

        //转化为存储过程中的类型，如：decimal(18,4)
        //public string GetSqlProcType
        //{

        //}
        //public override string ToString()
        //{
        //    throw new Exception("ColumnSchema.ToString() 已经禁用");
        //    string typeString = SqlType;
        //    if (MaxLength > 0 && (UniteType == UniteSqlType.NString || UniteType == UniteSqlType.String)) typeString = string.Format("{0}({1})", SqlType, MaxLength);
        //    return string.Format("{0} ({1}{2}{3})",
        //                         Name,
        //                         IsPrimary ? "PK, " : string.Empty,
        //                         string.Format("{0}, ", typeString),
        //                         IsNull ? "null" : "not null"
        //        );
        //}
    }

    [Serializable]
    public class ColumnSchemaCollection : List<ColumnSchema>
    {
    }
}
