using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SqlCodeGenerator
{
    public class SqlDataScriptGenerator
    {
        #region "生成数据脚本"
        /// <summary>
        /// Generate Data Script
        /// </summary>
        /// <param name="tableName">table name</param>
        /// <param name="dataTable">data table</param>
        /// <returns>string</returns>
        public static string GenerateDataScript(string tableName,DataTable dataTable)
        {
            StringBuilder mainBuilder = new StringBuilder();

            StringBuilder columnBuilder = new StringBuilder();
            columnBuilder.Append("Insert [" + tableName + "] (");
            foreach (DataColumn dc in dataTable.Columns)
            {
                columnBuilder.Append("[" + dc.ColumnName + "],");
            }
            columnBuilder.Replace(',', ')', columnBuilder.Length - 1, 1);
            columnBuilder.Append(" Values (");

            StringBuilder valuesBuilder = new StringBuilder();
            foreach (DataRow dr in dataTable.Rows)
            {
                valuesBuilder.Clear();
                mainBuilder.Append(columnBuilder.ToString());
                foreach(DataColumn dc in dataTable.Columns)
                {
                    if (dc.DataType.Name == "String")
                    {
                        valuesBuilder.Append("N'" + dr[dc].ToString() + "',");
                    }
                    else
                    {
                        valuesBuilder.Append(dr[dc].ToString()+",");
                    }                    
                }
                valuesBuilder.Replace(',', ')', valuesBuilder.Length - 1, 1);
                mainBuilder.AppendLine(valuesBuilder.ToString());
            }
            columnBuilder.Clear();
            return mainBuilder.ToString();
        }
        #endregion
    }
}
