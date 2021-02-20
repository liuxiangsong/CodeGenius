using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Collections;
using LibraryGenius;

namespace CodeGenius.VB
{
    class LFTwoTier
    {
        private StringBuilder builderDAL=new StringBuilder();
        private StringBuilder builderProcedure = new StringBuilder();

        private string strNameSpace = string.Empty;      //命名空间
        private string strSubfolder = string.Empty;      //子文件夹名
        private string strTableName = string.Empty;      //表名
  
        private string strIdentityColumn = string.Empty; 

        public  LFTwoTier(string strNameSpace, string strSubfolder, string strTableName)
        {
            if (string.IsNullOrEmpty(strTableName)) return;
            this.strNameSpace = strNameSpace + "." + strSubfolder;
            this.strNameSpace = this.strNameSpace.Trim('.');
            if (string.IsNullOrEmpty(this.strNameSpace))
            {
                this.strNameSpace = "CodeGenius";
            }
            this.strTableName = strTableName;
        }

        #region  生成Model层
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableColumnInfo">tableColumnInfo必须有一个相应的表名</param> 
        /// <param name="nameSpace">nameSpace</param>
        public string GenerateModelLayer(DataTable tableColumnInfo)
        { 
            string valueType = "";   //字段的初始值
            StringBuilder builder = new StringBuilder();
            StringBuilder builder_Sub = new StringBuilder();
            StringBuilder builder_Property = new StringBuilder();
            builder.AppendLine("Namespace" + this.strNameSpace);
            builder.AppendLine("Public Class " + this.strTableName + "Info");
            builder.AppendLine();
             
            foreach (DataRow row in tableColumnInfo.Rows)
            {
                string columnName = row["ColumnName"].ToString();
                string dataType = row["ColumnType"].ToString().ToLower();
                dataType = TypeHelper.DBTypeToVBType(dataType, out valueType);
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
            builder.AppendLine("End Namespace");
            builder_Property.Clear();
            builder_Sub.Clear();
            return builder.ToString();
        }
        #endregion

        #region 生成存儲過程和中間層代碼

        public string GenerateDALLayer(DataTable tableColumnInfo,string strIdentityColumn, ArrayList conditionList)
        {
            this.strIdentityColumn=strIdentityColumn;

            GetDAL_Fill(tableColumnInfo);
            GetDAL_GetList(tableColumnInfo, conditionList);
            GetDAL_Delete(tableColumnInfo, conditionList);
            GetDAL_Update(tableColumnInfo, conditionList);
            GetDAL_Add(tableColumnInfo, conditionList);
            return this.builderDAL.ToString();
        }

        public string GenerateProc(DataTable tableColumnInfo,string strIdentityColumn,ArrayList conditionList)
        { 
            this.strIdentityColumn=strIdentityColumn;
             
            GetProc_GetList(tableColumnInfo,conditionList);
            GetProc_Delete(tableColumnInfo,conditionList);
            GetProc_Update(tableColumnInfo,conditionList);
            GetProc_Add(tableColumnInfo,conditionList);
            return this.builderProcedure.ToString();
        }

        /// <summary>
        /// 生成存储过程和DAL层中Fill方法，生成文件时此方法应放在其它方法前
        /// </summary>
        /// <param name="tableColumnInfo"></param>
        private void GetDAL_Fill(DataTable tableColumnInfo)
        {
            StringBuilder builder = new StringBuilder();         //生成填充代碼
            builder.AppendLine("Imports System.Data.SqlClient");
            builder.AppendLine("Imports System.Data.Common");
            builder.AppendLine("Imports System.Data.Sql\r\n");
            builder.AppendLine("Namespace " + this.strNameSpace);
            builder.AppendLine("Public Class " + this.strTableName + "Controller");
            builder.AppendLine("Friend Function Fill" + this.strTableName + "(ByVal reader As IDataReader) As " + this.strTableName + "Info");
            builder.AppendLine("Dim objInfo as New " + this.strTableName + "Info");
              
            foreach (DataRow row in tableColumnInfo.Rows)
            {
                string columnName = row["ColumnName"].ToString();
                string dataType = row["ColumnType"].ToString().ToLower();
            if(strIdentityColumn.ToLower()==columnName.ToLower())continue;                  
                switch (dataType)
                {
                    case "numeric":
                    case "decimal":
                        builder.AppendLine("If reader(\"" + columnName + "\") Is DBNull.Value Then");
                        builder.AppendLine("objInfo." + columnName + "=Nothing");
                        builder.AppendLine("Else");
                        builder.AppendLine("objInfo." + columnName + "=CDbl(reader(\"" + columnName + "\").ToString)");
                        builder.AppendLine("End If");
                        break;
                    case "datetime":
                        builder.AppendLine("If reader(\"" + columnName + "\") Is DBNull.Value Then");
                        builder.AppendLine("objInfo." + columnName + "=Nothing");
                        builder.AppendLine("Else");
                        builder.AppendLine("objInfo." + columnName + "=Format(CDate(reader(\"" + columnName + "\")), \"yyyy/MM/dd\")");
                        builder.AppendLine("End If");
                        break;
                    case "bit":
                        builder.AppendLine("If reader(\"" + columnName + "\") Is DBNull.Value Then");
                        builder.AppendLine("objInfo." + columnName + "=Nothing");
                        builder.AppendLine("Else");
                        builder.AppendLine("objInfo." + columnName + "=reader(\"" + columnName + "\")");
                        builder.AppendLine("End If");
                        break;
                    default:
                        builder.AppendLine("objInfo." + columnName + "=reader(\"" + columnName + "\").ToString");
                        break;
                }
            }
            builder.AppendLine("Return objInfo");
            builder.AppendLine("End Function");
            builderDAL.AppendLine(builder.ToString());
            builder.Clear();
        }

        private void GetDAL_GetList(DataTable tableColumnInfo, ArrayList strList)
        { 
            StringBuilder builderDALParameter = new StringBuilder();
            StringBuilder builderDALAddInPara = new StringBuilder(); 
            foreach (string str in strList)
            {
                string dataType_Proc = "", dataType_Net = "";
                foreach (DataRow dr in tableColumnInfo.Rows)
                {
                    string valueType;
                    dataType_Net = dr["ColumnType"].ToString();
                    dataType_Proc = TypeHelper.DBTypeToProcType(dr);
                    dataType_Net =TypeHelper.DBTypeToVBType(dataType_Net, out valueType);
                } 
                builderDALParameter.Append("ByVal " + str + " As " + dataType_Net + ",");
                builderDALAddInPara.AppendLine("db.AddInParameter(dbComm, \"@" + str + "\",DbType." + dataType_Net + "," + str + ")");
            }
            builderDALParameter = builderDALParameter.Remove(builderDALParameter.ToString().LastIndexOf(","), 1);

            builderDAL.AppendLine("\r\nPublic Function " + this.strTableName + "_GetList(" + builderDALParameter.ToString() + ") As List(Of " + strTableName + "Info)");
            builderDAL.AppendLine("Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)");
            builderDAL.AppendLine("Dim dbComm As DbCommand = db.GetStoredProcCommand(\"" + this.strTableName + "_GetList\")");
            builderDAL.Append(builderDALAddInPara.ToString());
            builderDAL.AppendLine("Dim FeatureList As New List(Of " + this.strTableName + "Info)");
            builderDAL.AppendLine("Using reader As IDataReader = db.ExecuteReader(dbComm)");
            builderDAL.AppendLine("While reader.Read");
            builderDAL.AppendLine(" FeatureList.Add(Fill" + this.strTableName + "(reader))");
            builderDAL.AppendLine("End While");
            builderDAL.AppendLine("Return FeatureList");
            builderDAL.AppendLine("End Using");
            builderDAL.AppendLine("End Function\r"); 
            builderDALParameter.Clear();
            builderDALAddInPara.Clear();
        }

        private void GetDAL_Delete(DataTable tableColumnInfo, ArrayList strList)
        { 
            StringBuilder builder_CtrlParameter = new StringBuilder();
            StringBuilder builder_CtrlAddInPara = new StringBuilder();
             
            foreach (string str in strList)
            {
                string dataType_Proc = "", dataType_Net = "";
                foreach (DataRow dr in tableColumnInfo.Rows)
                {
                    string valueType;
                    dataType_Proc =TypeHelper.DBTypeToProcType(dr);
                    dataType_Net = dr["ColumnType"].ToString();
                    dataType_Net =TypeHelper.DBTypeToVBType(dataType_Net, out valueType);
                }
                builder_CtrlParameter.Append("ByVal " + str + " As " + dataType_Net + ",");
                builder_CtrlAddInPara.AppendLine("db.AddInParameter(dbComm, \"@" + str + "\",DbType." + dataType_Net + "," + str + ")");
                 
            }
            builder_CtrlParameter = builder_CtrlParameter.Remove(builder_CtrlParameter.ToString().LastIndexOf(","), 1);

            builderDAL.AppendLine("\r\nPublic Function " + this.strTableName + "_Delete(" + builder_CtrlParameter.ToString() + ") As Boolean");
            builderDAL.AppendLine("Try");
            builderDAL.AppendLine("Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)");
            builderDAL.AppendLine("Dim dbComm As DbCommand = db.GetStoredProcCommand(\"" + this.strTableName + "_Delete\")");
            builderDAL.Append(builder_CtrlAddInPara.ToString());
            builderDAL.AppendLine("db.ExecuteNonQuery(dbComm)");
            builderDAL.AppendLine(this.strTableName + "_Delete=True");
            builderDAL.AppendLine("Catch ex As Exception");
            builderDAL.AppendLine(" MsgBox(ex.Message)");
            builderDAL.AppendLine(this.strTableName + "_Delete=False");
            builderDAL.AppendLine("End Try");
            builderDAL.AppendLine("End Function");
            builder_CtrlAddInPara.Clear();
            builder_CtrlParameter.Clear();
        }

        private void GetDAL_Update(DataTable tableColumnInfo, ArrayList strList)
        {
            builderDAL.AppendLine("\r\nPublic Function " + this.strTableName + "_Update(ByVal objinfo As " + this.strTableName + "Info) As Boolean");
            builderDAL.AppendLine("Try");
            builderDAL.AppendLine("Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)");
            builderDAL.AppendLine("Dim dbComm As DbCommand = db.GetStoredProcCommand(\"" + this.strTableName + "_Update\")");

            string dataType_Proc = "", dataType_Net = "";
            foreach (DataRow dr in tableColumnInfo.Rows)
            {
                string columnName = dr["ColumnName"].ToString();
                string dataType = dr["ColumnType"].ToString().ToLower();

                string valueType;
                dataType_Proc =TypeHelper.DBTypeToProcType(dr);
                dataType_Net = dr["ColumnType"].ToString();
                dataType_Net =TypeHelper.DBTypeToVBType(dataType_Net, out valueType);
                if (strIdentityColumn.ToLower() == columnName.ToLower()) continue; 

                switch (dataType)
                {
                    case "datetime":
                        builderDAL.AppendLine("If objinfo." + columnName + "=Nothing Then");
                        builderDAL.AppendLine("db.AddInParameter(dbComm, \"@" + columnName + "\",DbType.Date,DBNull.Value)");
                        builderDAL.AppendLine("Else");
                        builderDAL.AppendLine("db.AddInParameter(dbComm, \"@" + columnName + "\",DbType.Date,objinfo." + columnName + ")");
                        builderDAL.AppendLine("End If");
                        break;
                    default:
                        builderDAL.AppendLine("db.AddInParameter(dbComm, \"@" + columnName + "\",DbType." + dataType_Net + ",objinfo." + columnName + ")");
                        break;
                }
            }
            builderDAL.AppendLine("db.ExecuteNonQuery(dbComm)");
            builderDAL.AppendLine(this.strTableName + "_Update=True");
            builderDAL.AppendLine("Catch ex As Exception");
            builderDAL.AppendLine(" MsgBox(ex.Message)");
            builderDAL.AppendLine(this.strTableName + "_Update=False");
            builderDAL.AppendLine("End Try");
            builderDAL.AppendLine("End Function");
        }

        /// <summary>
        /// 生成存储过程和DAL层中ADD方法，生成文件时此方法应放在其它方法之后
        /// </summary>
        /// <param name="tableColumnInfo"></param>
        /// <param name="strList"></param>
        private void GetDAL_Add(DataTable tableColumnInfo, ArrayList strList)
        {
            builderDAL.AppendLine("\r\nPublic Function " + this.strTableName + "_Add(ByVal objInfo as " + this.strTableName + "Info) As Boolean");
            builderDAL.AppendLine("Try");
            builderDAL.AppendLine("Dim db As New Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(ConnStr)");
            builderDAL.AppendLine("Dim dbComm As DbCommand = db.GetStoredProcCommand(\"" + this.strTableName + "_Add\")");

            string dataType_Proc = "", dataType_Net = "";
            foreach (DataRow dr in tableColumnInfo.Rows)
            {
                string columnName = dr["ColumnName"].ToString();
                string dataType = dr["ColumnType"].ToString().ToLower();

                string valueType;
                dataType_Proc =TypeHelper.DBTypeToProcType(dr);
                dataType_Net = dr["ColumnType"].ToString();
                dataType_Net =TypeHelper.DBTypeToVBType(dataType_Net, out valueType);
                if (strIdentityColumn.ToLower() == columnName.ToLower())
                {
                    continue;
                } 
                switch (dataType)
                {
                    case "datetime":
                        builderDAL.AppendLine("If objInfo." + columnName + "=Nothing Then");
                        builderDAL.AppendLine("db.AddInParameter(dbComm, \"@" + columnName + "\",DbType.Date,DBNull.Value)");
                        builderDAL.AppendLine("Else");
                        builderDAL.AppendLine("db.AddInParameter(dbComm, \"@" + columnName + "\",DbType.Date,objinfo." + columnName + ")");
                        builderDAL.AppendLine("End If");
                        break;
                    default:
                        builderDAL.AppendLine("db.AddInParameter(dbComm, \"@" + columnName + "\",DbType." + dataType_Net + ",objInfo." + columnName + ")");
                        break;
                }
            }
            builderDAL.AppendLine("db.ExecuteNonQuery(dbComm)");
            builderDAL.AppendLine(this.strTableName + "_Add=True");
            builderDAL.AppendLine("Catch ex As Exception");
            builderDAL.AppendLine(" MsgBox(ex.Message)");
            builderDAL.AppendLine(this.strTableName + "_Add=False");
            builderDAL.AppendLine("End Try");
            builderDAL.AppendLine("End Function");
            builderDAL.AppendLine("End Class");
            builderDAL.AppendLine("End Namespace"); 
        }





        private void GetProc_GetList(DataTable tableColumnInfo,ArrayList strList )
        {
            StringBuilder builder1 = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();    //生成存儲過程中的strWhere語句
 
            builder1.AppendLine("-- =============================================");
            builder1.AppendLine("-- Author:");
            builder1.AppendLine("-- Create date: " + DateTime.Now.ToString("yyyy/MM/dd"));
            builder1.AppendLine("-- Description: ");
            builder1.AppendLine("-- =============================================");
            builder1.AppendLine("Create Procedure " + this.strTableName + "_GetList");
            foreach (string str in strList)
            {                 
                string dataType_Proc = "", dataType_Net = "";
                foreach (DataRow dr in tableColumnInfo.Rows)
                {
                    string valueType;
                    dataType_Net = dr["ColumnType"].ToString();
                    dataType_Proc =TypeHelper.DBTypeToProcType(dr);
                    dataType_Net =TypeHelper.DBTypeToVBType(dataType_Net, out valueType);
                }
                builder1.AppendLine(("@" + str.ToString()).PadRight(20, ' ') + " " + dataType_Proc + "=null,");
                builder2.AppendLine("+ Isnull(' and " + str.ToString() + "='''+ltrim(@" + str.ToString() + ")+'''','')"); 
            }
            
            builder1 = builder1.Remove(builder1.ToString().LastIndexOf(","), 1);
            builder1.AppendLine("As");
            builder1.AppendLine("Declare @strSQL         varchar(2000)       -- main Sql");
            builder1.AppendLine("Declare @strWhere       varchar(1000)       --Order by ");
            builder1.AppendLine("Set @strWhere=''");
            builder1.AppendLine("Set @strWhere=@strWhere");
            builder1.Append(builder2.ToString());
            builder1.AppendLine("If len(@strWhere)>0 Set @strWhere = stuff(@strWhere,1,4,' where ')");
            builder1.AppendLine("Set @strSQL ='select * from " + this.strTableName + "'+@strWhere ");
            builder1.AppendLine("Exec(@strSQL)");

            builderProcedure.Append(builder1.ToString() + "\r");
            builder1.Clear();
            builder2.Clear(); 
        }

        private void GetProc_Delete(DataTable tableColumnInfo, ArrayList strList)
        {
            StringBuilder builder1 = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();    //生成strWhere語句 
            builder1.AppendLine("-- =============================================");
            builder1.AppendLine("-- Author:");
            builder1.AppendLine("-- Create date: " + DateTime.Now.ToString("yyyy/MM/dd"));
            builder1.AppendLine("-- Description: ");
            builder1.AppendLine("-- =============================================");
            builder1.AppendLine("Create Procedure " + this.strTableName + "_Delete");
            foreach (string str in strList)
            { 
                string dataType_Proc = "", dataType_Net = "";
                foreach (DataRow dr in tableColumnInfo.Rows)
                {
                    string valueType;
                    dataType_Proc =TypeHelper.DBTypeToProcType(dr);
                    dataType_Net = dr["ColumnType"].ToString();
                    dataType_Net =TypeHelper.DBTypeToVBType(dataType_Net, out valueType);
                }  
                builder1.AppendLine(("@" + str.ToString()).PadRight(20, ' ') + " " + dataType_Proc + ",");
                builder2.AppendLine("+ Isnull(' and " + str.ToString() + "='''+ltrim(@" + str.ToString() + ")+'''','')");
            }
             
            builder1 = builder1.Remove(builder1.ToString().LastIndexOf(","), 1);
            builder1.AppendLine("AS");
            builder1.AppendLine("Declare @strSQL   \t varchar(600)        -- main sql");
            builder1.AppendLine("Declare @strOrder \t varchar(400)        -- order by");
            builder1.AppendLine("Declare @strWhere \t varchar(1000)       -- select where");
            builder1.AppendLine("Set @strWhere=''");
            builder1.AppendLine("Set @strWhere=@strWhere");
            builder1.Append(builder2.ToString());
            builder1.AppendLine("If len(@strWhere)<>0 ");
            builder1.AppendLine("Begin");
            builder1.AppendLine("If len(@strWhere)>0 Set @strWhere = stuff(@strWhere,1,4,' where ')");
            builder1.AppendLine("Set @strSQL='delete from " + this.strTableName + " '+ @strWhere");
            builder1.AppendLine("Exec (@strSQL)");
            builder1.AppendLine("End"); 
            builderProcedure.Append(builder1.ToString() + "\r\r");
            builder1.Clear();
            builder2.Clear(); 
        }

        private void GetProc_Update(DataTable tableColumnInfo, ArrayList strList)
        {
            StringBuilder builder = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();
            
            builder.AppendLine("-- =============================================");
            builder.AppendLine("-- Author:");
            builder.AppendLine("-- Create date: " + DateTime.Now.ToString("yyyy/MM/dd"));
            builder.AppendLine("-- Description: ");
            builder.AppendLine("-- =============================================");
            builder.AppendLine("Create Procedure " + this.strTableName + "_Update");
 
            string dataType_Proc = "", dataType_Net = "";
            foreach (DataRow dr in tableColumnInfo.Rows)
            {
                string columnName = dr["ColumnName"].ToString();
                string dataType = dr["ColumnType"].ToString().ToLower();

                string valueType;
                dataType_Proc =TypeHelper.DBTypeToProcType(dr);
                dataType_Net = dr["ColumnType"].ToString();
                dataType_Net =TypeHelper.DBTypeToVBType(dataType_Net, out valueType);
                if (strIdentityColumn.ToLower() == columnName.ToLower()) continue;             
          
                builder.AppendLine(("@" + columnName).PadRight(20, ' ') + " " + dataType_Proc + ",");
                builder2.AppendLine(columnName + "=@" + columnName + ",");
                
            }             

            builder = builder.Remove(builder.ToString().LastIndexOf(","), 1);
            builder.AppendLine("As");
            builder.AppendLine("Update  " + this.strTableName + "\rSet");
            builder2 = builder2.Remove(builder2.ToString().LastIndexOf(","), 1);
            builder.Append(builder2.ToString()); 
            string whereString = "";
            foreach (string str in strList)
            {
                whereString += str.ToString() + "=@" + str.ToString() + " and ";
            };
            whereString = whereString.Substring(0, whereString.LastIndexOf(" and ") + 1);
            builder.Append("Where " + whereString);

            builderProcedure.Append(builder.ToString() + "\r\r\r");
            builder.Clear();
            builder2.Clear();
        }

        /// <summary>
        /// 生成存储过程和DAL层中ADD方法，生成文件时此方法应放在其它方法之后
        /// </summary>
        /// <param name="tableColumnInfo"></param>
        /// <param name="strList"></param>
        private void GetProc_Add(DataTable tableColumnInfo, ArrayList strList)
        { 
            StringBuilder builder = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();
            StringBuilder builder3 = new StringBuilder();
            builder.AppendLine("-- =============================================");
            builder.AppendLine("-- Author:");
            builder.AppendLine("-- Create date: " + DateTime.Now.ToString("yyyy/MM/dd"));
            builder.AppendLine("-- Description: ");
            builder.AppendLine("-- =============================================");
            builder.AppendLine("Create Procedure " + this.strTableName + "_Add"); 

            string dataType_Proc = "", dataType_Net = "";
            foreach (DataRow dr in tableColumnInfo.Rows)
            {
                string columnName = dr["ColumnName"].ToString();
                string dataType = dr["ColumnType"].ToString().ToLower();

                string valueType;
                dataType_Proc =TypeHelper.DBTypeToProcType(dr);
                dataType_Net = dr["ColumnType"].ToString();
                dataType_Net =TypeHelper.DBTypeToVBType(dataType_Net, out valueType);
                if (strIdentityColumn.ToLower() == columnName.ToLower())
                {
                    continue;
                }

                builder.AppendLine(("@" + columnName).PadRight(20, ' ') + " " + dataType_Proc + ",");
                builder2.AppendLine(columnName + ",");
                builder3.AppendLine("@" + columnName + ","); 
            }
            
            builder = builder.Remove(builder.ToString().LastIndexOf(","), 1);
            builder.AppendLine("As");
            builder.AppendLine("Insert into " + this.strTableName + "(");
            builder2 = builder2.Remove(builder2.ToString().LastIndexOf(","), 1);
            builder.Append(builder2.ToString());
            builder.AppendLine(")");
            builder.AppendLine("Values(");
            builder3 = builder3.Remove(builder3.ToString().LastIndexOf(","), 1);
            builder.Append(builder3.ToString());
            builder.AppendLine(")");
            builderProcedure.AppendLine(builder.ToString() + "\r\r\r");
            builder.Clear();
            builder2.Clear();
            builder3.Clear();
        }

        #endregion 
    }
}
