using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
//using System.Windows.Forms;

namespace SqlCodeGenerator
{
   public class ProcdureGenerator
    {
        #region 定义变量
        ArrayList pkeyList = null;         //table's Priamry Key Column Name List
       string strIdentity = string.Empty;     //table's Identity Column's Name
       string strAuthor = System.Security.Principal.WindowsIdentity.GetCurrent().Name;  //The Create Procedure User
        DBHelper.SqlUtil  otherMethods = new DBHelper.SqlUtil();
        #endregion

        #region 生成全部存储过程
        public string GenerateProc(string tableName, string sqlConnectionString)
        {
            pkeyList =DBHelper.SqlUtil.GetSqlTablePkeyColumn(tableName);
            strIdentity = DBHelper.SqlUtil.GetSqlTableIdentityColumn(tableName);
            StringBuilder procdureBuilder = new StringBuilder();
            procdureBuilder.AppendLine(GenerateGetListProc(tableName, sqlConnectionString));
            procdureBuilder.AppendLine(GenerateAddProc(tableName, sqlConnectionString));
            procdureBuilder.AppendLine(GenerateUpdateProc(tableName, sqlConnectionString));
            procdureBuilder.AppendLine(GenerateDeleteProc(tableName, sqlConnectionString));
            return procdureBuilder.ToString();
        }
        #endregion

        #region 生成存储过程GetList
        private string GenerateGetListProc(string tableName, string sqlConnectionString)
        {
            StringBuilder getListProcBuilder = new StringBuilder();
            getListProcBuilder.AppendLine(GenerateHeaderPart(tableName + "_GetList", strAuthor, null));
            getListProcBuilder.AppendLine(GenerateParameterPart(tableName, "GetList", sqlConnectionString));
            getListProcBuilder.AppendLine(GenerateMainPart(tableName, "GetList", sqlConnectionString));
            return getListProcBuilder.ToString();
        }
        #endregion

        #region 生成存储过程Add
        private string GenerateAddProc(string tableName, string sqlConnectionString)
        {
            StringBuilder addProcBuilder = new StringBuilder();
            addProcBuilder.AppendLine(GenerateHeaderPart(tableName + "_Add", strAuthor, null));
            addProcBuilder.AppendLine(GenerateParameterPart(tableName, "Add", sqlConnectionString));
            addProcBuilder.AppendLine(GenerateMainPart(tableName, "Add", sqlConnectionString));
            return addProcBuilder.ToString();
        }
        #endregion

        #region 生成存储过程Update
        private string GenerateUpdateProc(string tableName,string sqlConnectionString)
        {
            StringBuilder updateProcBuilder = new StringBuilder();
            updateProcBuilder.AppendLine(GenerateHeaderPart(tableName + "_Update", strAuthor, null));
            updateProcBuilder.AppendLine(GenerateParameterPart(tableName, "Update", sqlConnectionString));
            updateProcBuilder.AppendLine(GenerateMainPart(tableName, "Update", sqlConnectionString));
            return updateProcBuilder.ToString();
        }
        #endregion

        #region 生成存储过程Delete
        private string GenerateDeleteProc(string tableName, string sqlConnectionString)
        {
            StringBuilder deleteProcBuilder = new StringBuilder();
            deleteProcBuilder.AppendLine(GenerateHeaderPart(tableName + "_Delete", strAuthor, null));
            deleteProcBuilder.AppendLine(GenerateParameterPart(tableName, "Delete", sqlConnectionString));
            deleteProcBuilder.AppendLine(GenerateMainPart(tableName, "Delete", sqlConnectionString));
            return deleteProcBuilder.ToString();
        }
        #endregion

       
        #region 生成存储过程注释和首句部分
        /// <summary>
        /// Generate Notes and Header of Procedure
        /// </summary>
        /// <param name="spName">Procedure Name </param>
        /// <param name="author">Create Procedure User</param>
        /// <param name="description">Description Procedure Purpose</param>
        /// <returns></returns>
        private string GenerateHeaderPart(string spName, string author, string description)
        {
            StringBuilder headerBuilder = new StringBuilder();
            headerBuilder.AppendLine("-- ========================================================");
            headerBuilder.AppendLine("-- Entity Name:" + spName);
            headerBuilder.AppendLine("-- Author:" + author);
            headerBuilder.AppendLine("-- Create date: " + DateTime.Now.ToString("yyyy/MM/dd HH:ss"));
            headerBuilder.AppendLine("-- Description: " + description);
            headerBuilder.AppendLine("-- ========================================================");
            headerBuilder.AppendLine("Create Procedure " + spName);
            return headerBuilder.ToString();
        }
        #endregion

        #region 生成存储过程参数部分
        /// <summary>
        /// Generate Parameter of Procedure
        /// </summary>
        /// <param name="tableName">Table Name</param>
        /// <param name="isWhereParameter">If the procedure has condition parameter</param>
        /// <returns></returns>
        private string GenerateParameterPart(string tableName, string procedureType, string sqlConnectionString)
        {
            DataTable dtColumnInfo = null;
            StringBuilder parameterBuilder = new StringBuilder();
            switch (procedureType)
            {
                case "GetList":
                    #region
                    if (pkeyList.Count > 0)
                    {
                        foreach (string columnName in pkeyList)
                        {
                            string sqlStr = "select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" + tableName + "' and COLUMN_NAME='" + columnName + "' ";
                            DataTable table = DBHelper.SqlHelper.ExecuteDataTable(sqlStr);
                            string dataType_Proc = DBTypeConvertProcType(table.Rows[0]);
                            parameterBuilder.AppendLine(("@" + columnName).PadRight(20, ' ') + " " + dataType_Proc + "=null,");
                        }
                        parameterBuilder = parameterBuilder.Remove(parameterBuilder.ToString().LastIndexOf(","), 1);
                    }
                    else if (string.IsNullOrEmpty(strIdentity) == false)
                    {
                        string sqlStr = "select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" + tableName + "' and COLUMN_NAME='" + strIdentity + "' ";
                        DataTable table = DBHelper.SqlHelper.ExecuteDataTable(sqlStr);
                        string dataType_Proc = DBTypeConvertProcType(table.Rows[0]);
                        parameterBuilder.AppendLine(("@" + strIdentity).PadRight(20, ' ') + " " + dataType_Proc);
                    }
                    #endregion
                    break;
                case "Delete":
                    #region
                    if (pkeyList.Count > 0)
                    {
                        foreach (string columnName in pkeyList)
                        {
                            string sqlStr = "select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" + tableName + "' and COLUMN_NAME='" + columnName + "' ";
                            DataTable table = DBHelper.SqlHelper.ExecuteDataTable(sqlStr);
                            string dataType_Proc = DBTypeConvertProcType(table.Rows[0]);
                            parameterBuilder.AppendLine(("@" + columnName).PadRight(20, ' ') + " " + dataType_Proc + ",");
                        }
                        parameterBuilder = parameterBuilder.Remove(parameterBuilder.ToString().LastIndexOf(","), 1);
                    }
                    else if (string.IsNullOrEmpty(strIdentity) == false)
                    {
                        string sqlStr = "select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" + tableName + "' and COLUMN_NAME='" + strIdentity + "' ";
                        DataTable table = DBHelper.SqlHelper.ExecuteDataTable(sqlStr);
                        string dataType_Proc = DBTypeConvertProcType(table.Rows[0]);
                        parameterBuilder.AppendLine(("@" + strIdentity).PadRight(20, ' ') + " " + dataType_Proc);
                    }
                    #endregion
                    break;
                case "Update":
                    #region
                    dtColumnInfo =DBHelper.SqlUtil.GetSqlTableInfo(tableName,sqlConnectionString);
                    foreach (DataRow dr in dtColumnInfo.Rows)
                    {
                        string sqlStr = "select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" + tableName + "' and COLUMN_NAME='" + dr["ColumnName"].ToString() + "' ";
                        DataTable table = DBHelper.SqlHelper.ExecuteDataTable(sqlStr);
                        string dataType_Proc = DBTypeConvertProcType(table.Rows[0]);
                        parameterBuilder.AppendLine(("@" + dr["ColumnName"].ToString()).PadRight(20, ' ') + " " + dataType_Proc + ",");
                    }
                    parameterBuilder = parameterBuilder.Remove(parameterBuilder.ToString().LastIndexOf(","), 1);
                    #endregion
                    break;
                case "Add":
                    #region
                    dtColumnInfo = DBHelper.SqlUtil.GetSqlTableInfo(tableName, sqlConnectionString);
                    foreach (DataRow dr in dtColumnInfo.Rows)
                    {
                        if (int.Parse(dr["IsIdentity"].ToString()) != 1)
                        {
                            string sqlStr = "select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='" + tableName + "' and COLUMN_NAME='" + dr["ColumnName"] + "' ";
                            DataTable table = DBHelper.SqlHelper.ExecuteDataTable(sqlStr);
                            string dataType_Proc = DBTypeConvertProcType(table.Rows[0]);
                            parameterBuilder.AppendLine(("@" + dr["ColumnName"].ToString()).PadRight(20, ' ') + " " + dataType_Proc + "=null,");
                        }
                    }
                    parameterBuilder = parameterBuilder.Remove(parameterBuilder.ToString().LastIndexOf(","), 1);
                    #endregion
                    break;
            }
            return parameterBuilder.ToString();
        }
        #endregion

        #region 生成存储过程主要部分
        /// <summary>
        /// Generate Main of Procedure
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="procedureType"></param>
        /// <returns></returns>
        private string GenerateMainPart(string tableName, string procedureType, string sqlConnectionString)
        {
            DataTable dtColumnInfo = null;
            StringBuilder mainBuilder = new StringBuilder();
            mainBuilder.AppendLine("AS");
            switch (procedureType)
            {
                case "GetList":
                case "Delete":
                    #region
                    mainBuilder.AppendLine("Declare @strSQL         varchar(2000) ");
                    mainBuilder.AppendLine("Declare @strWhere       varchar(1000) ");
                    mainBuilder.AppendLine("Set @strWhere=''");
                    mainBuilder.AppendLine("Set @strWhere=@strWhere");
                    #region
                    if (pkeyList.Count > 0)
                    {
                        foreach (string columnName in pkeyList)
                        {
                            mainBuilder.AppendLine("+ Isnull(' and [" + columnName + "]='''+ltrim(@" + columnName + ")+'''','')");
                        }
                    }
                    else if (string.IsNullOrEmpty(strIdentity) == false)
                    {
                        mainBuilder.AppendLine("+ Isnull(' and [" + strIdentity + "]='''+ltrim(@" + strIdentity + ")+'''','')");
                    }
                    #endregion
                    mainBuilder.AppendLine("If len(@strWhere)>0 Set @strWhere = stuff(@strWhere,1,4,' where ')");
                    if (procedureType == "GetList")
                    {
                        mainBuilder.AppendLine("Set @strSQL ='select * from [" + tableName + "]'+@strWhere ");
                    }
                    else
                    {
                        mainBuilder.AppendLine("Set @strSQL ='delete from [" + tableName + "]'+@strWhere ");
                    }
                    mainBuilder.AppendLine("Exec(@strSQL)");
                    break;
                    #endregion
                case "Update":
                    #region
                    mainBuilder.AppendLine("Update [" + tableName + "]");
                    mainBuilder.AppendLine("Set");
                    dtColumnInfo = DBHelper.SqlUtil.GetSqlTableInfo(tableName, sqlConnectionString);
                    foreach (DataRow dr in dtColumnInfo.Rows)
                    {
                        if (int.Parse(dr["IsIdentity"].ToString()) != 1)
                        {
                            mainBuilder.AppendLine("[" + dr["ColumnName"].ToString() + "]=@" + dr["ColumnName"].ToString() + ",");
                        }
                    }
                    mainBuilder = mainBuilder.Remove(mainBuilder.ToString().LastIndexOf(","), 1);
                    #region
                    StringBuilder whereBuilder = new StringBuilder();
                    whereBuilder.AppendLine("Where ");
                    if (pkeyList.Count > 0)
                    {
                        foreach (string columnName in pkeyList)
                        {
                            whereBuilder.AppendLine("and [" + columnName + "]=@" + columnName);
                        }
                        whereBuilder = whereBuilder.Remove(whereBuilder.ToString().IndexOf("and"), 3);
                    }
                    else if (string.IsNullOrEmpty(strIdentity) == false)
                    {
                        whereBuilder.AppendLine("  [" + strIdentity + "]=@" + strIdentity);
                    }
                    #endregion
                    mainBuilder = mainBuilder.Append(whereBuilder.ToString());
                    break;
                    #endregion
                case "Add":
                    #region
                    mainBuilder.AppendLine("Insert Into [" + tableName + "] (");
                    StringBuilder valuesBuilder = new StringBuilder();
                    valuesBuilder.AppendLine("Values(");
                    dtColumnInfo = DBHelper.SqlUtil.GetSqlTableInfo(tableName, sqlConnectionString);
                    foreach (DataRow dr in dtColumnInfo.Rows)
                    {
                        if (int.Parse(dr["IsIdentity"].ToString()) != 1)
                        {
                            mainBuilder.AppendLine("[" + dr["ColumnName"].ToString() + "],");
                            valuesBuilder.AppendLine("@" + dr["ColumnName"].ToString() + ",");
                        }
                    }
                    mainBuilder = mainBuilder.Remove(mainBuilder.ToString().LastIndexOf(","), 1);
                    valuesBuilder = valuesBuilder.Remove(valuesBuilder.ToString().LastIndexOf(","), 1);
                    mainBuilder.AppendLine(")");
                    valuesBuilder.AppendLine(")");
                    mainBuilder.Append(valuesBuilder.ToString());
                    break;
                    #endregion
            }
            return mainBuilder.ToString();
        }
        #endregion

        #region 生成存儲過程時的數據類型轉化
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>return Procdure Type</returns>
        public string DBTypeConvertProcType(DataRow dr)
        {
            string convertedType = "";
            string dbType = dr["data_Type"].ToString().ToLower();
            string dataLength = dr["character_maximum_length"].ToString();
            string precisionLength = dr["numeric_precision"].ToString();
            string digitScale = dr["numeric_scale"].ToString(); //小數位位數

            switch (dbType)
            {
                case "varbinary":
                case "varchar":
                case "char":
                case "nchar":
                case "nvarchar":
                    if (dataLength == "-1")
                    {
                        dataLength = "Max";
                    }
                    convertedType = dbType + "(" + dataLength + ")";
                    return convertedType;
                case "numeric":
                case "decimal":
                    convertedType = dbType + "(" + precisionLength + "," + digitScale + ")";
                    return convertedType;
                case "bit":
                case "int":
                case "datetime":
                case "bigint":
                case "tinyint":
                case "date":
                case "float":
                case "image":
                case "money":
                case "ntext":
                case "smalldatetime":
                case "text":
                case "timestamp":
                case "uniqueidentifier":
                case "smallint":
                case "smallmoney":
                case "real":
                case "time":
                case "xml":
                    return dbType;
                default:
                    //throw new Exception("數據類型轉化時含未定義類型:" + dbType + "");
                    //MessageBox.Show("數據類型轉化時含未定義類型:" + dbType + "", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return dbType;
            }
        }
        #endregion
    }
}
