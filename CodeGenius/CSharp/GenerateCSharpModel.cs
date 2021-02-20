using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CodeGenius.CSharp
{
    class GenerateCSharpModel
    {
        public StringBuilder GenerateVBModel(string tableName)
        {
            string valueType = "";   //字段的初始值
            StringBuilder builder = new StringBuilder();
            StringBuilder builder_Sub = new StringBuilder();
            StringBuilder builder_Property = new StringBuilder();

            DataTable table = SqlHelper.GetDataTable("select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" + tableName + "'");

            builder.AppendLine("Public Class " + tableName + "Info");
            builder.AppendLine("{");

            foreach (DataRow row in table.Rows)
            {
                string columnName = row["Column_Name"].ToString();
                string dataType = row["Data_Type"].ToString().ToLower();
                dataType = Methods.DBTypeConvertNetType(dataType, out valueType);
                builder.AppendLine("\tprivate"+  dataType+"  _" + columnName );
                //builder_Sub.AppendLine("\t\t_" + columnName + " =  " + valueType);
                builder_Property.AppendLine("\tPublic "+ dataType +" " + columnName);
                builder_Property.AppendLine("{");
                builder_Property.AppendLine("\t\tGet{ Return _" + columnName+";}");
                builder_Property.AppendLine("\t\tSet{ _" + columnName + " =value;}"); 
                builder_Property.AppendLine("\t\t}");
            }
            builder.AppendLine(builder_Property.ToString());
            builder.AppendLine("}");
            builder_Property.Clear();
            builder_Sub.Clear();
            return builder;
        }
    }
}
