using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CodeGenius.VB
{
    public class GenerateVBModel
    {
        public StringBuilder GenerateVBModel(string tableName)
        {
            string valueType = "";   //字段的初始值
            StringBuilder builder = new StringBuilder();
            StringBuilder builder_Sub = new StringBuilder();
            StringBuilder builder_Property = new StringBuilder();

            DataTable table = SqlHelper.GetDataTable("select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" + tableName + "'");

            builder.AppendLine("Public Class " + tableName + "Info");
            builder.AppendLine();

            foreach (DataRow row in table.Rows)
            {
                string columnName = row["Column_Name"].ToString();
                string dataType = row["Data_Type"].ToString().ToLower();
                dataType = Methods.DBTypeConvertNetType(dataType, out valueType);
                builder.AppendLine("\tPrivate _" + columnName + " As " + dataType);
                builder_Sub.AppendLine("\t\t_" + columnName + " =  " + valueType);
                builder_Property.AppendLine("\tPublic Property " + columnName + "() As " + dataType);
                builder_Property.AppendLine("\t\tGet");
                builder_Property.AppendLine("\t\t\tReturn _" + columnName);
                builder_Property.AppendLine("\t\tEnd Get");
                builder_Property.AppendLine("\t\tSet(ByVal value As " + dataType + ")");
                builder_Property.AppendLine("\t\t\t_" + columnName + " =value");
                builder_Property.AppendLine("\t\tEnd Set");
                builder_Property.AppendLine("\tEnd Property");
            }
            builder.AppendLine("\tPublic Sub New()");
            builder.AppendLine(builder_Sub.ToString());
            builder.AppendLine("\tEnd Sub");
            builder.AppendLine(builder_Property.ToString());
            builder.AppendLine("End Class");
            builder_Property.Clear();
            builder_Sub.Clear();
            return builder;

        }
    }
}
