using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using LibraryGenius;

namespace CodeGenius.CSharp
{
    class LFThreeTier
    {
        private string strNameSpace = string.Empty;      //命名空间
        private string strSubfolder = string.Empty;      //子文件夹名
        private string strTableName = string.Empty;      //表名
        private string strIdentityColumn = string.Empty;

        public LFThreeTier(string strNameSpace,string strSubfolder, string strTableName)
        {
            if (string.IsNullOrEmpty(strTableName)) return;
            this.strNameSpace = strNameSpace + "." + strSubfolder;
            this.strNameSpace = this.strNameSpace.Trim('.');
            if (string.IsNullOrEmpty(this.strNameSpace))
            {
                //this.strNameSpace = "CodeGenius"; 
            }
            this.strTableName = strTableName;
        }

        #region  生成Model层
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableColumnInfo">tableColumnInfo</param> 
        /// <param name="nameSpace">nameSpace</param>
        public string GenerateModelLayer(DataTable tableColumnInfo)
        {
            string m_strNameSpace = this.strNameSpace + ".Model." + this.strSubfolder;            
            StringBuilder builder_Field = new StringBuilder(); 
            StringBuilder builder_Property = new StringBuilder();
            builder_Field.AppendLine("using System;");
            builder_Field.AppendLine("using System.Collections.Generic;");
            builder_Field.AppendLine("using System.Linq;");
            builder_Field.AppendLine("using System.Text;\r");
            builder_Field.AppendLine("namespace " + m_strNameSpace.Trim('.'));
            builder_Field.AppendLine("{");
            builder_Field.AppendLine("public partial class " + this.strTableName + "Info");
            builder_Field.AppendLine("{"); 
            builder_Field.AppendLine("#region Field Members");
            builder_Property.AppendLine("#region Property Members");

            foreach (DataRow row in tableColumnInfo.Rows)
            {
                string columnName = row["ColumnName"].ToString();
                string dataType = row["ColumnType"].ToString().ToLower();
                string columnDescr=row["columnDescr"].ToString();
                dataType = TypeHelper.SqlTypeStringToCsharpNullableTypeString(dataType);  
                //builder_Field.Append("Private " + dataType + " m_" + columnName + ";");
                //builder_Field.AppendLine(string.IsNullOrEmpty(columnDescr) ? "" : "//" + columnDescr);
                builder_Field.Append("public const string " +  columnName +"_Field=\""+columnName+ "\";");
                builder_Field.AppendLine(string.IsNullOrEmpty(columnDescr)?"":"\t\t//"+columnDescr);

                builder_Property.AppendLine("/// <summary>");
                builder_Property.AppendLine("/// " + columnDescr+" "+TypeHelper.DBTypeToProcType(row));
                builder_Property.AppendLine("/// <summary>");
                builder_Property.AppendLine("public "+ dataType+" " + columnName);
                //builder_Property.AppendLine("{\rset{m_" + columnName+"=value;}");
                //builder_Property.AppendLine("get{return m_" + columnName+";}\r}"); 
                builder_Property.AppendLine("{\rset;");
                builder_Property.AppendLine("get;\r}");   
            }
            builder_Field.AppendLine("#endregion\r");
            builder_Property.AppendLine("#endregion");
            builder_Field.AppendLine(builder_Property.ToString());
            builder_Field.AppendLine("}");
            builder_Field.AppendLine("}");
            builder_Property.Clear(); 
            return builder_Field.ToString();
        }
        #endregion

        #region Generate DAL Layer
        public string GenerateDALLayer(DataTable tableColumnInfo)
        {
            string m_strModelNameSpace = this.strNameSpace + ".Model." + this.strSubfolder;
            string m_strNameSpace = this.strNameSpace + ".DAL." + this.strSubfolder;
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("using System;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine("using System.Linq;");
            builder.AppendLine("using System.Text;");
            builder.AppendLine("using System.Data;");
            builder.AppendLine("using DAL.Common;");
            builder.AppendLine("using " + m_strModelNameSpace.Trim('.')+";\r");
            builder.AppendLine("namespace " + m_strNameSpace.Trim('.'));
            builder.AppendLine("{");
            builder.AppendLine("public class DAL"+this.strTableName+":DALBase<"+this.strTableName+"Info>");
            builder.AppendLine("{");
            builder.AppendLine("private static DAL"+this.strTableName+" instance=null;");
            builder.AppendLine("private DAL" + this.strTableName + "()");
            builder.AppendLine("{");
            builder.AppendLine("this._tableName=\""+this.strTableName+"\";");
            foreach (DataRow row in tableColumnInfo.Rows)
            {
                builder.Append("this._columnInfos.Add(\"" + row["ColumnName"].ToString() + "\",new ColumnInfo(SqlDbType.");
                builder.Append( TypeHelper.SqlTypeStringToSqlDbType(row["ColumnType"].ToString()) + "," +Convert.ToBoolean(row["IsIdentity"]).ToString().ToLower());
                builder.AppendLine("," + row["ColumnLength"].ToString() + "));");
            }
            builder.AppendLine("}\r");
            builder.AppendLine("public static DAL" + this.strTableName+" GetInstance()");
            builder.AppendLine("{");
            builder.AppendLine("if (instance == null)");
            builder.AppendLine("{");
            builder.AppendLine("instance = new DAL" + this.strTableName+"();");
            builder.AppendLine("}");
            builder.AppendLine("return instance;");
            builder.AppendLine("}");
            builder.AppendLine("}");
            builder.AppendLine("}");
            return builder.ToString();
        }
        #endregion

        #region Generate BLL Layer
        public string GenerateBLLLayer(DataTable tableColumnInfo)
        {
            string m_strModelNameSpace = this.strNameSpace + ".Model." + this.strSubfolder;
            string m_strDALNameSpace = this.strNameSpace + ".DAL." + this.strSubfolder;
            string m_strNameSpace = this.strNameSpace + ".BLL." + this.strSubfolder;
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("using System;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine("using System.Linq;");
            builder.AppendLine("using System.Text;");
            builder.AppendLine("using System.Data;");
            builder.AppendLine("using System.Collections;");
            builder.AppendLine("using " + m_strModelNameSpace.Trim('.') + ";");
            builder.AppendLine("using " + m_strDALNameSpace.Trim('.') + ";\r");
            builder.AppendLine("namespace " + m_strNameSpace.Trim('.'));
            builder.AppendLine("{");
            builder.AppendLine("public class BLL" + this.strTableName);
            builder.AppendLine("{");
            builder.AppendLine("/// <summary>");
            builder.AppendLine("/// 插入数据");
            builder.AppendLine("/// </summary>");
            builder.AppendLine("/// <param name=\"objInfo\">" + this.strTableName + "Info对象</param>");
            builder.AppendLine("/// <returns></returns>");
            builder.AppendLine("public static bool Insert("+this.strTableName+"Info  objInfo)");
            builder.AppendLine("{");
            builder.AppendLine("return DAL" + this.strTableName+".GetInstance().Insert(objInfo)>0;");
            builder.AppendLine("}\r");
            builder.AppendLine("/// <summary>");
            builder.AppendLine("/// 更新数据,当没有指定的列时，更新值不为空的列");
            builder.AppendLine("/// </summary>");
            builder.AppendLine("/// <param name=\"objInfo\">" + this.strTableName + "Info对象</param>");
            builder.AppendLine("/// <param name=\"strCondition\">修改数据的条件</param>");
            builder.AppendLine("/// <param name=\"arrayCols\">需要修改的列，为空时只更新值不为空的列</param>");
            builder.AppendLine("/// <returns></returns>");
            builder.AppendLine("public static bool Update(" + this.strTableName + "Info  objInfo,string strCondition,ArrayList arrayCols=null)");
            builder.AppendLine("{");
            builder.AppendLine("return DAL" + this.strTableName + ".GetInstance().Update(objInfo,strCondition,arrayCols)>-1;");
            builder.AppendLine("}\r");
            builder.AppendLine("/// <summary>");
            builder.AppendLine("/// 删除数据");
            builder.AppendLine("/// </summary>");
            builder.AppendLine("/// <param name=\"strCondition\">删除数据的条件</param>");
            builder.AppendLine("/// <param name=\"strNotes\">操作日志備注說明</param>");
            builder.AppendLine("/// <returns></returns>");
            builder.AppendLine("public static bool Delete(string strCondition,string strNotes=\"\")");
            builder.AppendLine("{");
            builder.AppendLine("return DAL" + this.strTableName + ".GetInstance().Delete(strCondition)>-1;");
            builder.AppendLine("}\r");
            builder.AppendLine("/// <summary>");
            builder.AppendLine("/// 审核");
            builder.AppendLine("/// </summary>");
            builder.AppendLine("/// <param name=\"objInfo\">" + this.strTableName + "Info对象</param>");
            builder.AppendLine("/// <param name=\"strCondition\">审核指定数据行的条件</param>");
            builder.AppendLine("/// <returns></returns>");
            builder.AppendLine("public static bool Check(" + this.strTableName + "Info  objInfo,string strCondition)");
            builder.AppendLine("{");
            builder.AppendLine("return DAL" + this.strTableName + ".GetInstance().Check(objInfo,strCondition)>-1;");
            builder.AppendLine("}\r");

            builder.AppendLine("/// <summary>");
            builder.AppendLine("\t\t/// 指定表名查詢");
            builder.AppendLine("\t\t/// </summary>");
            builder.AppendLine("\t\t/// <param name=\"strTableName\">表名</param>");
            builder.AppendLine("\t\t/// <param name=\"strCondition\"></param>");
            builder.AppendLine("\t\t/// <returns></returns>");
            builder.AppendLine("\t\tpublic static DataTable GetCustomTable(string strTableName, string strCondition = null)");
            builder.AppendLine("\t\t{");
            builder.AppendLine("\t\t\treturn DAL" + this.strTableName + ".GetInstance().GetCustomTable(strTableName, strCondition);");
            builder.AppendLine("\t\t}\r");

            builder.AppendLine("/// <summary>");
            builder.AppendLine("/// 取得符合条件的表");
            builder.AppendLine("/// </summary>");
            builder.AppendLine("/// <param name=\"strCondition\">查询的条件</param>");
            builder.AppendLine("///<param name=\"strCols\">查詢的列</param>");
            builder.AppendLine("/// <returns>返回符合条件的数据表</returns>");
            builder.AppendLine("public static DataTable GetTable(string strCondition,string strCols=null)");
            builder.AppendLine("{");
            builder.AppendLine("return DAL" + this.strTableName + ".GetInstance().GetTable(strCondition,strCols);");
            builder.AppendLine("}\r");
            builder.AppendLine("///<summary>");
            builder.AppendLine("///取得新的流水号");
            builder.AppendLine("///</summary>");
            builder.AppendLine("///<param name=\"strSNColoumn\">流水号列</param>");
            builder.AppendLine("///<param name=\"strSNPrefix\">流水号前辍</param>");
            builder.AppendLine("///<param name=\"SNNum\">流水号位数（如PO1401010001，流水号位数为4）</param>");
            builder.AppendLine("///<returns>新的流水号</returns>");
            builder.AppendLine("public static string GetNewSN(string strSNColoumn,string strSNPrefix,int SNNum=6)");
            builder.AppendLine("{");
            builder.AppendLine("return DAL" + this.strTableName + ".GetInstance().GetNewSN(strSNColoumn,strSNPrefix,SNNum);");
            builder.AppendLine("}\r");

            builder.AppendLine("public static bool IsSNCheck(string strCondition)");
            builder.AppendLine("{");
            builder.AppendLine("return DAL" + this.strTableName + ".GetInstance().IsSNCheck(strCondition);");
            builder.AppendLine("}\r");

            builder.AppendLine("public static bool IsExists(string strCondition)");
            builder.AppendLine("{");
            builder.AppendLine("return DAL" + this.strTableName + ".GetInstance().IsExists(strCondition);");
            builder.AppendLine("}\r");

            builder.AppendLine("public static List<" + this.strTableName + "Info> GetList(DataTable dt)");
            builder.AppendLine("{");
            builder.AppendLine("return DAL" + this.strTableName + ".GetInstance().GetList(dt);");
            builder.AppendLine("}");

            builder.AppendLine("}");
            builder.AppendLine("}"); 
            return builder.ToString();
        }
        #endregion

        #region Generate DAL Layer's Common Class
        public string GenerateDALCommonClass()
        {
            #region
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("using System;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine("using System.Linq;");
            builder.AppendLine("using System.Text;");
            builder.AppendLine("using System.Data;");
            builder.AppendLine("using System.Collections;");
            builder.AppendLine("using System.Data.SqlClient;\r");
            builder.AppendLine("namespace DAL.Common");
            builder.AppendLine("{");
            builder.AppendLine("public abstract class DALBase<ModelClass>");
            builder.AppendLine("{");
            builder.AppendLine("#region Property");
            builder.AppendLine("protected string _tableName;");
            builder.AppendLine("protected Dictionary<string, ColumnInfo> _columnInfos = new Dictionary<string, ColumnInfo>();");
            builder.AppendLine("public string TableName");
            builder.AppendLine("{");
            builder.AppendLine("get { return _tableName; }");
            builder.AppendLine("}\r");
            builder.AppendLine("public Dictionary<string, ColumnInfo> ColumnInfos");
            builder.AppendLine("{");
            builder.AppendLine(" get { return _columnInfos; }");
            builder.AppendLine("}");
            builder.AppendLine("#endregion\r");
            #endregion
            #region
            builder.AppendLine("#region 增、删、改、审核");
            builder.AppendLine("/// <summary>");
            builder.AppendLine("///插入数据");
            builder.AppendLine("/// </summary>");
            builder.AppendLine("/// <param name=\"objInfo\">要插入数据类的实例</param>"); 
            builder.AppendLine("/// <returns>执行结果，受影响的行数</returns>");
            builder.AppendLine(" public virtual int Insert(ModelClass objInfo)");
            builder.AppendLine("{");
            builder.AppendLine("string sqlText;");
            builder.AppendLine("int returnValue = 0;");
            builder.AppendLine("StringBuilder colsBuilder = new StringBuilder();");
            builder.AppendLine("StringBuilder valuesBuilder = new StringBuilder();");
            builder.AppendLine(" if (objInfo == null) return returnValue;");
            builder.AppendLine("foreach (KeyValuePair<string, ColumnInfo> kvp in _columnInfos)");
            builder.AppendLine("{");
            builder.AppendLine("if(kvp.Value.IsIdentity) continue;");
            builder.AppendLine("colsBuilder.AppendLine(\", \" + kvp.Key);");
            builder.AppendLine("valuesBuilder.AppendLine(\", @\" + kvp.Key);"); 
            builder.AppendLine("}");
            builder.AppendLine("sqlText = string.Format(\"insert into {0} ({1}) values({2})\", this._tableName, colsBuilder.ToString().Trim(','), valuesBuilder.ToString().Trim(','));");
            builder.AppendLine("returnValue = DBHelper.SQLHelper.ExcuteNonQuery(sqlText, GetParams(objInfo));");
            builder.AppendLine("return returnValue;");
            builder.AppendLine("}\r");
            builder.AppendLine("/// <summary>");
            builder.AppendLine("///更新数据,当指定条件指定列为空时更新值不为空的列");
            builder.AppendLine("/// </summary>");
            builder.AppendLine("/// <param name=\"objInfo\">要更新数据类的实例</param>");
            builder.AppendLine("/// <param name=\"strCondition\">更新数据的条件</param>");
            builder.AppendLine("/// <param name=\"arrayCols\">更新的列</param>");
            builder.AppendLine("/// <returns>执行结果，受影响的行数</returns>");
            builder.AppendLine(" public virtual int Update(ModelClass objInfo,string strCondition,ArrayList arrayCols=null)");
            builder.AppendLine("{");
            builder.AppendLine("string sqlText;");
            builder.AppendLine("StringBuilder sqlBuilder = new StringBuilder();");
            builder.AppendLine("sqlBuilder.AppendLine(String.Format(\"update {0} set \", this._tableName));");
            builder.AppendLine("int returnValue = 0;");
            builder.AppendLine(" if (objInfo == null) return returnValue;");
            builder.AppendLine("if (arrayCols != null)");
            builder.AppendLine("{");
            builder.AppendLine("foreach (string strCol in arrayCols)");
            builder.AppendLine("{");
            builder.AppendLine("sqlBuilder.AppendLine(String.Format(\"{0}=@{0},\", strCol));"); 
            builder.AppendLine("}");
            builder.AppendLine("}");
            builder.AppendLine("else");
            builder.AppendLine("{");
            builder.AppendLine("foreach (KeyValuePair<string, ColumnInfo> kvp in _columnInfos)");
            builder.AppendLine("{");
            builder.AppendLine("if (kvp.Value.IsIdentity) continue;");
            builder.AppendLine("if (GetValue(objInfo, kvp.Key) != null)");
            builder.AppendLine("sqlBuilder.AppendLine(String.Format(\"{0}=@{0},\", kvp.Key));");
            builder.AppendLine("}");
            builder.AppendLine("}");
            builder.AppendLine("sqlText = sqlBuilder.ToString().Trim(',');");
            builder.AppendLine("sqlText += \" where \" + strCondition;");
            builder.AppendLine(" returnValue = DBHelper.SQLHelper.ExcuteNonQuery(sqlText, GetParams(objInfo));");
            builder.AppendLine("return returnValue;");
            builder.AppendLine("}\r");
            builder.AppendLine("/// <summary>");
            builder.AppendLine("///删除指定条件的数据");
            builder.AppendLine("/// </summary>");
            builder.AppendLine("/// <param name=\"strCondition\">删除数据的条件</param>");
            builder.AppendLine("/// <returns>执行结果，受影响的行数</returns>");
            builder.AppendLine("public virtual int Delete(string strCondition)");
            builder.AppendLine("{");
            builder.AppendLine("int returnValue = 0;");
            builder.AppendLine("if(string.IsNullOrEmpty(strCondition))return returnValue;");
            builder.AppendLine(" string sqlString = String.Format(\"delete from {0} where {1}\", this._tableName, strCondition);");
            builder.AppendLine("returnValue = DBHelper.SQLHelper.ExcuteNonQuery(sqlString);");
            builder.AppendLine("return returnValue;");
            builder.AppendLine("}\r");
            builder.AppendLine("/// <summary>");
            builder.AppendLine("///审核");
            builder.AppendLine("/// </summary>");
            builder.AppendLine("/// <param name=\"strCondition\">审核指定数据行的条件</param>");
            builder.AppendLine("/// <returns>执行结果，受影响的行数</returns>");
            builder.AppendLine(" public virtual int Check(ModelClass objInfo,string strCondition)");
            builder.AppendLine("{");
            builder.AppendLine("StringBuilder sqlBuilder = new StringBuilder();");
            builder.AppendLine("sqlBuilder.AppendLine(String.Format(\"update {0} set \", this._tableName));");
            builder.AppendLine("sqlBuilder.AppendLine(\"CheckBit=@CheckBit,\");");
            builder.AppendLine("sqlBuilder.AppendLine(\"CheckDate=getdate(),\");");
            builder.AppendLine("sqlBuilder.AppendLine(\"CheckRemark=@CheckRemark,\");");
            builder.AppendLine("sqlBuilder.AppendLine(\"CheckUserID=@CheckUserID\");");
            builder.AppendLine("sqlBuilder.AppendLine(\"where \"+strCondition);");
            builder.AppendLine("return DBHelper.SQLHelper.ExcuteNonQuery(sqlBuilder.ToString(), GetParams(objInfo));");
            builder.AppendLine("}\r");
            builder.AppendLine("\t\t/// <summary>");
            builder.AppendLine("\t\t/// 指定表名查詢");
            builder.AppendLine("\t\t/// </summary>");
            builder.AppendLine("\t\t/// <param name=\"strTableName\">表名</param>");
            builder.AppendLine("\t\t/// <param name=\"strCondition\"></param>");
            builder.AppendLine("\t\t/// <returns></returns>");
            builder.AppendLine("public virtual DataTable GetCustomTable(string strTableName, string strCondition = null)");
            builder.AppendLine("\t\t{");
            builder.AppendLine("\t\t\tstring sqlString = \"select * from [\" + strTableName + \"] \"; ");
            builder.AppendLine("\t\t\tif (string.IsNullOrEmpty(strCondition) == false)");
            builder.AppendLine("\t\t\t{");
            builder.AppendLine("\t\t\t\tsqlString += \" where \" + strCondition;");
            builder.AppendLine("\t\t\t}");
            builder.AppendLine("\t\t\treturn DBHelper.SQLHelper.GetDataTable(sqlString);");
            builder.AppendLine("\t\t}");
            builder.AppendLine("/// <summary>");
            builder.AppendLine("///单表查询");
            builder.AppendLine("/// </summary>");
            builder.AppendLine("/// <param name=\"strCondition\">查询符合指定条件的数据行</param>");
            builder.AppendLine("/// <returns>返回表</returns>");
            builder.AppendLine("public virtual DataTable GetTable(string strCondition,string cols=null)");
            builder.AppendLine("\t\t{");
            builder.AppendLine("\t\t\tstring sqlString = \"select * from [\" + this._tableName + \"] \";");
            builder.AppendLine("\t\t\tif (string.IsNullOrEmpty(cols)==false)");
            builder.AppendLine("\t\t\t{");
            builder.AppendLine("\t\t\t\tSystem.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(\"\\\\*\");");
            builder.AppendLine("\t\t\t\tsqlString = regex.Replace(sqlString, cols);");
            builder.AppendLine("\t\t\t}");
            builder.AppendLine("\t\t\tif (string.IsNullOrEmpty(strCondition)==false)");
            builder.AppendLine("\t\t\t{");
            builder.AppendLine("\t\t\t\tsqlString += \" where \" + strCondition;");
            builder.AppendLine("\t\t\t}");
            builder.AppendLine("\t\t\treturn DBHelper.SQLHelper.GetDataTable(sqlString);");
            builder.AppendLine("\t\t}");

            builder.AppendLine("///<summary>");
            builder.AppendLine("///取得新的流水号");
            builder.AppendLine("///</summary>");
            builder.AppendLine("///<param name=\"strSNColoumn\">流水号列</param>");
            builder.AppendLine("///<param name=\"strSNPrefix\">流水号前辍</param>");
            builder.AppendLine("///<param name=\"SNNum\">流水号位数（如POyyMM0001，流水号位数为4）</param>");
            builder.AppendLine("///<returns>新的流水号</returns>");
            builder.AppendLine("public virtual string GetNewSN(string strSNColoumn,string strSNPrefix,int SNNum=6)");
            builder.AppendLine("{");
            builder.AppendLine("StringBuilder sqlBuilder = new StringBuilder();");
            builder.AppendLine("sqlBuilder.AppendLine(String.Format(\"select top 1 {0} from {1} \",strSNColoumn, this._tableName));");
            builder.AppendLine("sqlBuilder.AppendLine(String.Format(\" where {0} like ''{1}'+convert(nvarchar(4),getDate(),12)+'%'' \",strSNColoumn, strSNPrefix));");
            builder.AppendLine("foreach (KeyValuePair<string, ColumnInfo> kvp in _columnInfos)");
            builder.AppendLine("{");
            builder.AppendLine("if(kvp.Value.isIdentity)");
            builder.AppendLine("{");
            builder.AppendLine("sqlBuilder.AppendLine(\"order by \"+kvp.Key+\" desc\");");
            builder.AppendLine("break;");
            builder.AppendLine("}");
            builder.AppendLine("}"); 
            builder.AppendLine("string strMaxSN=DBHelper.SQLHelper.GetExecuteScalar(sqlBuilder.ToString()).ToString();");
            builder.AppendLine(" if (strMaxSN == null)");
            builder.AppendLine(" return strSNPrefix +DBHelper.SQLHelper.GetServerDateTime(\"yyMM\") + \"1\".PadLeft(SNNum, '0');");
            builder.AppendLine("");
            builder.AppendLine("");
            builder.AppendLine("int num = Convert.ToInt32(strMaxSN.Substring(strSNPrefix.Length+4)) + 1;");
            builder.AppendLine("return strMaxSN.Remove(strSNPrefix.Length + 4) + num.ToString().PadLeft(SNNum, '0');");
            builder.AppendLine("}\r");
            builder.AppendLine("\t/// <summary>");
            builder.AppendLine("\t\t/// 檢查單號是否已審核");
            builder.AppendLine("\t\t/// </summary>");
            builder.AppendLine("\t\t/// <param name=\"strCondition\">查詢的條件</param>");
            builder.AppendLine("\t\t/// <returns>返回True表示已審核</returns>");
            builder.AppendLine("\t\tpublic virtual bool IsSNCheck(string strCondition)");
            builder.AppendLine("\t\t{");
            builder.AppendLine("\t\t\tstring sqlString = string.Format(\"select count(1) from {0} where IsCheck=1 and {1}\", this._tableName, strCondition);");
            builder.AppendLine("\t\t\treturn DBHelper.SQLHelper.IsExists(sqlString);");
            builder.AppendLine("\t\t}");
            builder.AppendLine("\t/// <summary>");
            builder.AppendLine("\t\t/// 檢查表中是否存在符合條件的記錄");
            builder.AppendLine("\t\t/// </summary>");
            builder.AppendLine("\t\t/// <param name=\"strCondition\"></param>");
            builder.AppendLine("\t\t/// <returns></returns>");
            builder.AppendLine("\t\tpublic virtual bool IsExists(string strCondition)");
            builder.AppendLine("\t\t{");
            builder.AppendLine("\t\t\tstring sqlString = string.Format(\"select count(1) from {0} where {1}\", this._tableName, strCondition);");
            builder.AppendLine("\t\t\treturn DBHelper.SQLHelper.IsExists(sqlString);");
            builder.AppendLine("\t\t}");
            builder.AppendLine("#endregion\r");
            #endregion
            #region
            builder.AppendLine(" #region 将表转化为数据类集合");
            builder.AppendLine("/// <summary>");
            builder.AppendLine("/// 将表转化为数据类集合");
            builder.AppendLine("/// </summary>");
            builder.AppendLine("/// <param name=\"dt\">要转化的表</param>");
            builder.AppendLine("/// <returns>返回对象集合</returns>");
            builder.AppendLine("public List<ModelClass> GetList(DataTable dt)");
            builder.AppendLine("{");
            builder.AppendLine("List<ModelClass> list = new List<ModelClass>();");
            builder.AppendLine("ModelClass modelObj;"); 
            builder.AppendLine("foreach (DataRow dr in dt.Rows)");
            builder.AppendLine("{");
            builder.AppendLine("modelObj = Activator.CreateInstance<ModelClass>();");
            builder.AppendLine("foreach (KeyValuePair<string, ColumnInfo> kvp in this._columnInfos)");
            builder.AppendLine("{");
            builder.AppendLine("if (dr[kvp.Key] is DBNull)");
            builder.AppendLine("{");
            builder.AppendLine("switch (kvp.Value.DataType)//根据数据类型设置其为空时的默认值");
            builder.AppendLine("{");
            builder.AppendLine("case SqlDbType.Int:");
            builder.AppendLine("case SqlDbType.BigInt:");
            builder.AppendLine("case SqlDbType.SmallInt:");
            builder.AppendLine("case SqlDbType.TinyInt:");
            builder.AppendLine("case SqlDbType.Float:");
            builder.AppendLine("case SqlDbType.Real:");
            builder.AppendLine("this.SetValue(modelObj, kvp.Key, 0);");
            builder.AppendLine("break;");
            builder.AppendLine("case SqlDbType.Money:");
            builder.AppendLine("case SqlDbType.Decimal:");
            builder.AppendLine("case SqlDbType.SmallMoney:");
            builder.AppendLine("this.SetValue(modelObj, kvp.Key, 0.0M);");
            builder.AppendLine("break;");
            builder.AppendLine("case SqlDbType.Bit:");
            builder.AppendLine("this.SetValue(modelObj, kvp.Key, false);");
            builder.AppendLine("break;");
            builder.AppendLine("default:");
            builder.AppendLine("this.SetValue(modelObj, kvp.Key, null);");
            builder.AppendLine("break;");
            builder.AppendLine("}");
            builder.AppendLine("continue;");
            builder.AppendLine("}");
            builder.AppendLine("else if (kvp.Value.DataType == SqlDbType.Money || kvp.Value.DataType == SqlDbType.SmallMoney || kvp.Value.DataType == SqlDbType.Decimal)");
            builder.AppendLine("{");
            builder.AppendLine("this.SetValue(modelObj, kvp.Key, Convert.ToDecimal(dr[kvp.Key]));");
            builder.AppendLine("}");
            builder.AppendLine("else");
            builder.AppendLine("{");
            builder.AppendLine("this.SetValue(modelObj, kvp.Key, dr[kvp.Key]);");
            builder.AppendLine("}");
            builder.AppendLine("}");
            builder.AppendLine("list.Add(modelObj);");
            builder.AppendLine("}");
            builder.AppendLine("return list;");
            builder.AppendLine("}");
            builder.AppendLine("#endregion");
            #endregion
            builder.AppendLine("");

            #region
            builder.AppendLine("#region Other Methods");
            builder.AppendLine("private SqlParameter[] GetParams(object objInfo)");
            builder.AppendLine("{");
            builder.AppendLine("SqlParameter[] parameter = new SqlParameter[_columnInfos.Count];");
            builder.AppendLine("int i = 0;");
            builder.AppendLine("foreach (KeyValuePair<string, ColumnInfo> kvp in _columnInfos)");
            builder.AppendLine("{");
            builder.AppendLine("parameter[i++] = new SqlParameter(\"@\" + kvp.Key, kvp.Value.DataType) { Value = GetValue(objInfo, kvp.Key) };");
            builder.AppendLine("}");
            builder.AppendLine("return parameter;");
            builder.AppendLine("}\r");
            builder.AppendLine("/// <summary>");
            builder.AppendLine("///获取实例指定属性的值");
            builder.AppendLine("/// </summary>");
            builder.AppendLine("/// <param name=\"objInfo\">类型实例</param>");
            builder.AppendLine("/// <param name=\"propertyName\">属性名称</param>");
            builder.AppendLine("/// <returns>实例属性的值</returns>");
            builder.AppendLine(" private object GetValue(object objInfo, string propertyName)");
            builder.AppendLine("{");
            builder.AppendLine(" return objInfo.GetType().GetProperty(propertyName).GetValue(objInfo, null);");
            builder.AppendLine("}");
            builder.AppendLine("/// <summary>");
            builder.AppendLine("///设置实例指定属性的值");
            builder.AppendLine("/// </summary>");
            builder.AppendLine("/// <param name=\"objInfo\">类型实例</param>");
            builder.AppendLine("/// <param name=\"propertyName\">属性名称</param>");
            builder.AppendLine("/// <param name=\"value\">值</param>");
            builder.AppendLine("/// <returns></returns>");
            builder.AppendLine("  protected void SetValue(object objInfo,string propertyName, object value)");
            builder.AppendLine("{");
            builder.AppendLine("objInfo.GetType().GetProperty(propertyName).SetValue(objInfo,value, null);");
            builder.AppendLine("}");
            builder.AppendLine("#endregion");
            #endregion
            builder.AppendLine("}\r");
            builder.AppendLine("//--------------------------------------------------------------------------------------");
            builder.AppendLine(this.GenerateColumnInfoStruct());
            builder.AppendLine("}");
            return builder.ToString();
        }

        #region Generate ColumnInfo Struct 
        private string GenerateColumnInfoStruct()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("public struct ColumnInfo");
            builder.AppendLine("{");
            builder.AppendLine("#region Property");
            builder.AppendLine("private SqlDbType _dataType;  //数据类型");
            builder.AppendLine("private int _dataSize;  //数据长度");
            builder.AppendLine(" private bool _isIdentity;   //是否为自增长列");
            builder.AppendLine(" private bool _isKey;   //是否为主键（扩展用)");
            builder.AppendLine("public SqlDbType DataType");
            builder.AppendLine("{");
            builder.AppendLine("get { return _dataType; }");
            builder.AppendLine("}");
            builder.AppendLine("public bool IsIdentity");
            builder.AppendLine("{");
            builder.AppendLine("get { return _isIdentity; }");
            builder.AppendLine("}");
            builder.AppendLine("public int DataSize");
            builder.AppendLine("{");
            builder.AppendLine("get { return _dataSize; }");
            builder.AppendLine("}");
            builder.AppendLine("private bool IsKey");
            builder.AppendLine("{");
            builder.AppendLine("get { return _isKey; }");
            builder.AppendLine("}");
            builder.AppendLine("#endregion\r");
            builder.AppendLine("#region 构造方法");
            builder.AppendLine("public ColumnInfo(SqlDbType type, bool isIdentity, int size = 0, bool iskey = false)");
            builder.AppendLine("{");
            builder.AppendLine("_dataType = type;");
            builder.AppendLine("_isIdentity = isIdentity;");
            builder.AppendLine("_dataSize = size;");
            builder.AppendLine("_isKey = iskey;");
            builder.AppendLine("}");
            builder.AppendLine("#endregion");
            builder.AppendLine("}");
            return builder.ToString();
        }
        #endregion
        #endregion
    }
}
