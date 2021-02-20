using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CodeGenius.Entity
{
    [Serializable]
    public class ParameterSchema : DBObjectSchema
    {
        [Description("参数数据类型")]
        public string DataType { get; set; }

        [Description("参数类型")]
        public ParameterType ParameterType { get; set; }

        [Description("Length")]
        public Int16 Length { get; set; }

        [Description("NumericPrecision")]
        public Int16 NumericPrecision { get; set; }

        [Description("NumericScale")]
        public Int16 NumericScale { get; set; }

        [Description("DefaultValue")]
        public string DefaultValue { get; set; }
    }

    [Serializable]
    public class ParameterSchemaCollection : List<ParameterSchema>
    {
    }

    /// <summary>
    /// 表示一个数据键的类型的枚举
    /// </summary> 
[Serializable]
    public enum ParameterType
    {
        In,
        Out,
        None
    } 
}
