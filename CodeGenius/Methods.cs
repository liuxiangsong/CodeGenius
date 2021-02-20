using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Collections;
using System.Windows.Forms;
using System.IO;

namespace CodeGenius
{
   public class Methods
    {
        #region SQLDMO Methods
        /// <summary>
        /// Get Table Or View's SQL String
        /// </summary>
        /// <param name="isTable"></param>
        /// <param name="objectName">objectName's value is table or view</param>
        /// <returns>SQL String</returns>
        //public string GetTableOrViewSQLString(bool isTable, string objectName)
        //{
        //    string strSql, strServer, strUid, strPwd, strDatabase;
        //    bool IsWindowAuthentication = false;

        //    strServer = GetPartOfSqlString(@"server=\'(.+?)';", out IsWindowAuthentication);
        //    strUid = GetPartOfSqlString(@"uid=\'(.+?)';", out IsWindowAuthentication);
        //    strPwd = GetPartOfSqlString(@"pwd=\'(.+?)';", out IsWindowAuthentication);
        //    strDatabase = GetPartOfSqlString(@"database=\'(.+?)';", out IsWindowAuthentication);
        //    GetPartOfSqlString(@"Trusted_Connection=(.+?)", out IsWindowAuthentication);
        //    try
        //    {
        //        SQLDMO.SQLServer oServer = new SQLDMO.SQLServer();
        //        oServer.LoginSecure = IsWindowAuthentication;
        //        oServer.Connect(strServer, strUid, strPwd);
        //        SQLDMO._Database mydb = oServer.Databases.Item(strDatabase, "owner");
        //        if (isTable == true)
        //        {
        //            SQLDMO._Table myTable = mydb.Tables.Item(objectName, "dbo");
        //            strSql = myTable.Script(SQLDMO.SQLDMO_SCRIPT_TYPE.SQLDMOScript_Default, null, null, SQLDMO.SQLDMO_SCRIPT2_TYPE.SQLDMOScript2_Default);
        //            strSql += myTable.Script(SQLDMO.SQLDMO_SCRIPT_TYPE.SQLDMOScript_Default, null, null, SQLDMO.SQLDMO_SCRIPT2_TYPE.SQLDMOScript2_ExtendedOnly);
        //        }
        //        else
        //        {
        //            SQLDMO._View myView = mydb.Views.Item(objectName, "dbo");
        //            strSql = myView.Script(SQLDMO.SQLDMO_SCRIPT_TYPE.SQLDMOScript_Default, null, SQLDMO.SQLDMO_SCRIPT2_TYPE.SQLDMOScript2_Default);
        //        }
        //        oServer.DisConnect();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return strSql;
        //}

        private string GetPartOfSqlString(string pattern, out bool isExists)
        {
            Match match = Regex.Match(DBHelper.SqlHelper.SqlConnectionString, pattern);
            if (match.Success)
            {
                isExists = true;
                return match.Groups[1].Value;
            }
            isExists = false;
            return null;
        }
        #endregion

        

        //#region 把数据库中的类型转化为对应的DotNet类型(CS)
        //public static string DBTypeConvertNetType(string dataType)
        //{
        //    switch (dataType.ToLower())
        //    {
        //        case "int":
        //        case "smallint":
        //        case "bigint": 
        //            return "int?";
        //        case "nvarchar":
        //        case "nchar":
        //        case "char":
        //        case "varchar":
        //        case "ntext":
        //        case "text": 
        //            return "string";
        //        case "money":
        //        case "smallmoney":
        //        case "decimal":
        //        case "numeric": 
        //            return "decimal?";
        //        case "float": 
        //            return "double?";
        //        case "real": 
        //            return "single?";
        //        case "datetime2": 
        //            return "DateTime2?"; ;
        //        case "date":
        //        case "smalldatetime":
        //        case "datetime": ;
        //            return "DateTime?";
        //        case "bit": 
        //            return "bool?";
        //        case "tinyint": 
        //            return "byte?";
        //        case "binary":
        //        case "image":
        //        case "rowversion":
        //        case "timestamp":
        //        case "varbinary": 
        //            return "byte[]";
        //        case "uniqueidentifier": 
        //            return "Guid";
        //        case "xml": 
        //            return "xml";
        //        case "datetimeoffset": 
        //            return "datetimeoffset";
        //        case "time": 
        //            return "timeSpan";
        //    }
        //    MessageBox.Show("数据类型转化时含有未定义的类型:" + dataType + "", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    return dataType;
        //}
        //#endregion



        //#region 生成存储过程时的数据类型转化
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="drColumnInfo">dr必须为SqlTableColumnInfo 中的行</param>
        ///// <returns></returns>
        //public static string DBTypeConvertProcType(DataRow drColumnInfo)
        //{
        //    string convertedType = "";
        //    if (drColumnInfo == null)
        //    {
        //        MessageBox.Show("传入的列不能为空");
        //    }
        //    string dbType = drColumnInfo["ColumnType"].ToString().ToLower();
        //    string dataLength = drColumnInfo["ColumnLength"].ToString();
        //    string digitScale = drColumnInfo["Scale"].ToString(); //小數位位數

        //    switch (dbType)
        //    {
        //        case "varbinary":
        //        case "varchar":
        //        case "char":
        //        case "nchar":
        //        case "nvarchar":
        //            if (dataLength == "-1")
        //            {
        //                dataLength = "Max";
        //            }
        //            convertedType = dbType + "(" + dataLength + ")";
        //            return convertedType;

        //        case "numeric":
        //        case "decimal":
        //            convertedType = dbType + "(" + dataLength + "," + digitScale + ")";
        //            return convertedType;

        //        case "bit":
        //        case "int":
        //        case "datetime":
        //        case "bigint":
        //        case "tinyint":
        //        case "date":
        //        case "float":
        //        case "image":
        //        case "money":
        //        case "ntext":
        //        case "smalldatetime":
        //        case "text":
        //        case "timestamp":
        //        case "uniqueidentifier":
        //        case "smallint":
        //        case "smallmoney":
        //        case "real":
        //        case "time":
        //        case "xml":
        //            return convertedType = dbType;
        //        default:
        //            MessageBox.Show("数据类型转化时含有未定义的类型:" + dbType + "", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return convertedType = dbType;
        //    }
        //}
        //#endregion

        #region 保存文件
       /// <summary>
       /// 
       /// </summary>
       /// <param name="strFolderPath"></param>
       /// <param name="content"></param>
       /// <param name="fileName"></param>
       /// <returns></returns>
        public static bool SaveFile(string strFolderPath, string content, string fileName)
        {
            if (Directory.Exists(strFolderPath) == false)
            {
                Directory.CreateDirectory(strFolderPath);
            }
            if (File.Exists(strFolderPath +"\\"+ fileName) == true) 
            {
                if (MessageBox.Show(fileName + "is exists，do you want to replace", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.WriteAllText(strFolderPath +"\\"+ fileName, content);
                    return true;
                }
                else
                {
                    if (fileName.LastIndexOf(')') + 1 == fileName.LastIndexOf('.'))
                    {
                        int i = Convert.ToInt32(fileName.Substring(fileName.LastIndexOf('(') + 1, fileName.LastIndexOf(')') - fileName.LastIndexOf('(') - 1));
                        i += 1;
                        fileName = fileName.Remove(fileName.LastIndexOf('(') + 1) + i + fileName.Substring(fileName.LastIndexOf(')'));
                        SaveFile(strFolderPath, content, fileName);
                    }
                    else
                    {
                        fileName = fileName.Remove(fileName.LastIndexOf('.')) + "(1)" + fileName.Substring(fileName.LastIndexOf('.'));
                        SaveFile(strFolderPath, content, fileName);
                    }
                    return true;
                }
            }
            else
            {
                File.WriteAllText(strFolderPath + "\\" + fileName, content);
                return true;
            }
        }
        #endregion

    }
}
