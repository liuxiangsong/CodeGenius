using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Common;
using System.Data.Sql;

namespace Test
{
    //class Class2
    //{
    //    private void ScriptOption()
    //    {
    //        scriptOption.ContinueScriptingOnError = true;
    //        scriptOption.IncludeIfNotExists = true;
    //        scriptOption.NoCollation = true;
    //        scriptOption.ScriptDrops = false;
    //        scriptOption.ContinueScriptingOnError = true;
    //        //scriptOption.DriAllConstraints = true;
    //        scriptOption.WithDependencies = false;
    //        scriptOption.DriForeignKeys = true;
    //        scriptOption.DriPrimaryKey = true;
    //        scriptOption.DriDefaults = true;
    //        scriptOption.DriChecks = true;
    //        scriptOption.DriUniqueKeys = true;
    //        scriptOption.Triggers = true;
    //        scriptOption.ExtendedProperties = true;
    //        scriptOption.NoIdentities = false;
    //    }

    //    /// <summary>
    //    /// 生成数据库类型为SqlServer指定表的DDL
    //    /// </summary>
    //    private void GenerateSqlServerDDL()
    //    {
    //        //对于已经生成过的就不用再次生成了，节约资源。
    //        if (!string.IsNullOrEmpty(textEditorDDL.Text) && textEditorDDL.Text.Trim().Length > 10)
    //        {
    //            return;
    //        }

    //        ScriptOption();
    //        ServerConnection sqlConnection = null;
    //        try
    //        {
    //            StringBuilder sbOutPut = new StringBuilder();

    //            if (dbSet.ConnectStr.ToLower().Contains("integrated security")) //Windows身份验证
    //            {
    //                sqlConnection = new ServerConnection(dbSet.Server);
    //            }
    //            else        //SqlServer身份验证
    //            {
    //                string[] linkDataArray = dbSet.ConnectStr.Split(';');
    //                string userName = string.Empty;
    //                string pwd = string.Empty;
    //                foreach (string str in linkDataArray)
    //                {
    //                    if (str.ToLower().Replace(" ", "").Contains("userid="))
    //                    {
    //                        userName = str.Split('=')[1];
    //                    }

    //                    if (str.ToLower().Replace(" ", "").Contains("password"))
    //                    {
    //                        pwd = str.Split('=')[1];
    //                    }
    //                }

    //                sqlConnection = new ServerConnection(dbSet.Server, userName, pwd);
    //            }

    //            Server sqlServer = new Server(sqlConnection);
    //            Table table = sqlServer.Databases[dbSet.DbName].Tables[txtName.Text];
    //            string ids;
    //            //编写表的脚本
    //            sbOutPut = new StringBuilder();
    //            sbOutPut.AppendLine();
    //            sCollection = table.Script(scriptOption);

    //            foreach (String str in sCollection)
    //            {
    //                //此处修正smo的bug
    //                if (str.Contains("ADD  DEFAULT") && str.Contains("') AND type = 'D'"))
    //                {
    //                    ids = str.Substring(str.IndexOf("OBJECT_ID(N'") + "OBJECT_ID(N'".Length, str.IndexOf("') AND type = 'D'") - str.IndexOf("OBJECT_ID(N'") - "OBJECT_ID(N'".Length);
    //                    sbOutPut.AppendLine(str.Insert(str.IndexOf("ADD  DEFAULT") + 4, "CONSTRAINT " + ids));
    //                }
    //                else
    //                    sbOutPut.AppendLine(str);

    //                sbOutPut.AppendLine("GO");
    //            }

    //            //生成存储过程
    //            this.textEditorDDL.SetCodeEditorContent("SQL", sbOutPut.ToString());
    //            this.textEditorDDL.SaveFileName = this.TableName + ".sql";
    //            sbOutPut = new StringBuilder();
    //        }
    //        catch (Exception ex)
    //        {
    //            LogHelper.WriteException(ex);
    //        }
    //        finally
    //        {
    //            sqlConnection.Disconnect();
    //        }
    //    }

    //}

    class d
    {
        
    }
}
