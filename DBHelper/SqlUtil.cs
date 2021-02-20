using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data.SqlClient;

namespace DBHelper
{
    public class SqlUtil
    {
        #region 取得数据库表列的信息
        /// <summary>
        /// GetSqlTableColumnInfo
        /// </summary>
        /// <param name="tableName">tableName</param>
        /// <returns>return ColumnInfo Table</returns>
        public static DataTable GetSqlTableInfo(string tableName)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.AppendLine("select ColumnID=ORDINAL_POSITION,");
            sqlBuilder.AppendLine("ColumnName=COLUMN_NAME,");
            sqlBuilder.AppendLine("ColumnType=DATA_TYPE,");
            sqlBuilder.AppendLine("ColumnLength=COLUMNPROPERTY(OBJECT_ID(I.TABLE_NAME),COLUMN_NAME,'PRECISION'),");
            sqlBuilder.AppendLine("Scale=COLUMNPROPERTY(OBJECT_ID(I.TABLE_NAME),COLUMN_NAME,'Scale'),");
            sqlBuilder.AppendLine("IsIdentity=COLUMNPROPERTY(OBJECT_ID(I.TABLE_NAME),COLUMN_NAME,'IsIdentity'),");
            sqlBuilder.AppendLine("Ispkey=(SELECT 'True' FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME='" + tableName + "' AND COLUMN_NAME=I.COLUMN_NAME),");
            sqlBuilder.AppendLine("IsNullable=(case when IS_NULLABLE='Yes' then 'True' else 'False' end ), ");
            sqlBuilder.AppendLine("DefaultValue=COLUMN_DEFAULT,");
            sqlBuilder.AppendLine("ColumnDescr=(select value from sys.extended_properties P where class=1 and  OBJECT_ID(TABLE_NAME)=P.major_id and COLUMN_NAME=COL_NAME(P.major_id,P.minor_id) and name='MS_Description')");
            sqlBuilder.AppendLine("from INFORMATION_SCHEMA.COLUMNS as I ");
            sqlBuilder.AppendLine("where TABLE_NAME='" + tableName + "'");
            return SqlHelper.ExecuteDataTable(sqlBuilder.ToString());
        }

        public static DataTable GetSqlTableInfo(string tableName, string sqlConnectionString)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.AppendLine("select ColumnID=ORDINAL_POSITION,");
            sqlBuilder.AppendLine("ColumnName=COLUMN_NAME,");
            sqlBuilder.AppendLine("ColumnType=DATA_TYPE,");
            sqlBuilder.AppendLine("ColumnLength=COLUMNPROPERTY(OBJECT_ID(I.TABLE_NAME),COLUMN_NAME,'PRECISION'),");
            sqlBuilder.AppendLine("Scale=COLUMNPROPERTY(OBJECT_ID(I.TABLE_NAME),COLUMN_NAME,'Scale'),");
            sqlBuilder.AppendLine("IsIdentity=COLUMNPROPERTY(OBJECT_ID(I.TABLE_NAME),COLUMN_NAME,'IsIdentity'),");
            sqlBuilder.AppendLine("Ispkey=(SELECT 'True' FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME='" + tableName + "' AND COLUMN_NAME=I.COLUMN_NAME),");
            sqlBuilder.AppendLine("IsNullable=(case when IS_NULLABLE='Yes' then 'True' else 'False' end ), ");
            sqlBuilder.AppendLine("DefaultValue=COLUMN_DEFAULT,");
            sqlBuilder.AppendLine("ColumnDescr=(select value from sys.extended_properties P where class=1 and  OBJECT_ID(TABLE_NAME)=P.major_id and COLUMN_NAME=COL_NAME(P.major_id,P.minor_id) and name='MS_Description')");
            sqlBuilder.AppendLine("from INFORMATION_SCHEMA.COLUMNS as I ");
            sqlBuilder.AppendLine("where TABLE_NAME='" + tableName + "'");
            SqlHelper.SqlConnectionString = sqlConnectionString;
            return SqlHelper.ExecuteDataTable(sqlBuilder.ToString());
        }

        #endregion

        #region Get Table of Database  Identity Column
        public static string GetSqlTableIdentityColumn(string tableName)
        {
            string strSQL = "SELECT Name FROM SYS.COLUMNS WHERE OBJECT_ID=OBJECT_ID('" + tableName + "') AND IS_IDENTITY=1";
            using (IDataReader sdr = SqlHelper.ExecuteDataReader(strSQL))
            {
                if (sdr.Read())
                {
                    return sdr["Name"].ToString();
                }
                return string.Empty;
            }
        }
        #endregion

        #region Get Table of Database  Primary Key Column
        public static ArrayList GetSqlTablePkeyColumn(string tableName)
        {
            ArrayList pkeyList = new ArrayList();
            string strSQL = "exec sp_pkeys @table_name='" + tableName + "'";
            using (IDataReader sdr = SqlHelper.ExecuteDataReader(strSQL))
            {
                while (sdr.Read())
                {
                    pkeyList.Add(sdr["Column_Name"].ToString());
                }
                return pkeyList;
            }
        }
        #endregion

        #region SQLDMO Methods
        /// <summary>
        /// Get Table Or View's SQL String
        /// </summary>
        /// <param name="isTable"></param>
        /// <param name="objectName">objectName's value is table or view</param>
        /// <returns>SQL String</returns>
        public string GetTableOrViewSQLString(bool isTable, string objectName)
        {
            string strSql, strServer, strUid, strPwd, strDatabase;
            bool IsWindowAuthentication = false;

            strServer = GetPartOfSqlString(@"server=\'(.+?)';", out IsWindowAuthentication);
            strUid = GetPartOfSqlString(@"uid=\'(.+?)';", out IsWindowAuthentication);
            strPwd = GetPartOfSqlString(@"pwd=\'(.+?)';", out IsWindowAuthentication);
            strDatabase = GetPartOfSqlString(@"database=\'(.+?)';", out IsWindowAuthentication);
            GetPartOfSqlString(@"Trusted_Connection=(.+?)", out IsWindowAuthentication);
            try
            {
                SQLDMO.SQLServer oServer = new SQLDMO.SQLServer();
                oServer.LoginSecure = IsWindowAuthentication;
                oServer.Connect(strServer, strUid, strPwd);
                SQLDMO._Database mydb = oServer.Databases.Item(strDatabase, "owner");
                if (isTable == true)
                {
                    SQLDMO._Table myTable = mydb.Tables.Item(objectName, "dbo");
                    strSql = myTable.Script(SQLDMO.SQLDMO_SCRIPT_TYPE.SQLDMOScript_Default, null, null, SQLDMO.SQLDMO_SCRIPT2_TYPE.SQLDMOScript2_Default);
                    strSql += myTable.Script(SQLDMO.SQLDMO_SCRIPT_TYPE.SQLDMOScript_Default, null, null, SQLDMO.SQLDMO_SCRIPT2_TYPE.SQLDMOScript2_ExtendedOnly);
                }
                else
                {
                    SQLDMO._View myView = mydb.Views.Item(objectName, "dbo");
                    strSql = myView.Script(SQLDMO.SQLDMO_SCRIPT_TYPE.SQLDMOScript_Default, null, SQLDMO.SQLDMO_SCRIPT2_TYPE.SQLDMOScript2_Default);
                }
                oServer.DisConnect();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strSql;
        }

        private string GetPartOfSqlString(string pattern, out bool isExists)
        {
            Match match = Regex.Match(SqlHelper.SqlConnectionString, pattern);
            if (match.Success)
            {
                isExists = true;
                return match.Groups[1].Value;
            }
            isExists = false;
            return null;
        }
        #endregion


        /// <summary>
        /// 数据库对象重命名
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="oldName"></param>
        /// <param name="newName"></param>
        /// <param name="objType">'column'  'database'  'index'  'object'  'userdatatype'
        /// The @objtype parm is sometimes required.  It is always required
        /// for databases.  It is required whenever ambiguities would
        /// otherwise exist.  Explicit use of @objtype is always encouraged.</param>
        public static void DBObjectRename(string dbName, string oldName, string newName, string objType=null)
        {
            try
            {
                string sqlString = string.Format("use [{0}] EXEC sp_rename '{1}', '{2}','{3}'", dbName,oldName, newName, objType).TrimEnd(',');
                SqlHelper.ExecuteNonQuery(sqlString);
            }
            catch (Exception ex)
            {
                throw  new Exception(ex.Message);
            }


        }
    }
}
