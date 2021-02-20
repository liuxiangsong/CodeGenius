using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeGenius.Frame.TreeNodeBase;
using CodeGenius.Entity;
using LibraryGenius;

namespace MsSqlTree.TreeNode.Programmability
{
    public class Programmability_Parameter_Node : DbTreeNode
    {
        public Programmability_Parameter_Node()
        {
            Nodes.Clear();
        }
        public Programmability_Parameter_Node(ParameterSchema parameterSchema)
            : this()
        {
            string defaultValue = parameterSchema.DefaultValue;

            string sqlType = parameterSchema.DataType.ToLower();
            string sqlFullType = sqlType;
            int length = parameterSchema.Length;
            int precision = parameterSchema.NumericPrecision;
            int scale = parameterSchema.NumericScale;
            switch (sqlType)
            {
                case "binary":
                    sqlFullType = string.Format("binary({0})", length); break;
                case "char":
                    sqlFullType = string.Format("char({0})", length); break;
                case "nchar":
                    sqlFullType = string.Format("nchar({0})", length); break;
                case "varbinary":
                    sqlFullType = string.Format("varbinary({0})", ((length == int.MaxValue || length < 0) ? "MAX" : length.ToString())); break;
                case "varchar":
                    sqlFullType = string.Format("varchar({0})", ((length == int.MaxValue || length < 0) ? "MAX" : length.ToString())); break;
                case "nvarchar":
                    sqlFullType = string.Format("nvarchar({0})", ((length == int.MaxValue || length < 0) ? "MAX" : length.ToString())); break;
                case "time":
                    sqlFullType = string.Format("time({0})", length); break;
                case "datetime2":
                    sqlFullType = string.Format("datetime2({0})", length); break;
                case "datetimeoffset":
                    sqlFullType = string.Format("datetimeoffset({0})", length); break;
                case "decimal":
                    sqlFullType = string.Format("decimal({0}, {1})", precision, scale); break;
                case "numeric":
                    sqlFullType = string.Format("numeric({0}, {1})", precision, scale); break;
            }
            Text = parameterSchema.Name + "("
                + sqlFullType
                + (parameterSchema.ParameterType == ParameterType.Out ? ", 输出" : (parameterSchema.ParameterType == ParameterType.In ? ", 输入" : string.Empty))
                + (string.IsNullOrEmpty(defaultValue) ? ", 无默认值" : ", 默认 " + defaultValue)
                + ")";
            ImageKey = SelectedImageKey = parameterSchema.ParameterType == ParameterType.Out
                ? "SqlClient_DataParamOutput"
                : "SqlClient_DataParamInput";
        }
 

    }
}
