using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace SqlCodeGenerator
{
  public  class DBDataDocHtml
  {
      public delegate void SetProcessBarHandler(int value);
      public static event SetProcessBarHandler SetProcessBarEvent;

      #region "生成Html格式的数据库文档"
      /// <summary>
      /// generate Database Document file(html format)
      /// </summary>
      /// <param name="dbName">database name</param>
      /// <param name="ds">dataset(notice:every table must have a real table Name)</param>
      /// <param name="templateFilePath">The Html template file path </param> 
      public static string GenerateHtmlDBDocument(string dbName,DataSet ds,string templateFilePath)
      {
          StringBuilder builder = new StringBuilder();
          builder.Append("<div class=\"styledb\"> 数据库名：" + dbName + "</div>");
          for (int item = 0; item < ds.Tables.Count; item++)
          {
              builder.Append(FormatDataTable(ds.Tables[item]));
              SetProcessBarEvent(item + 1);  //Set Processbar's current value
          }

          #region 
          string str = string.Empty;
          if (File.Exists(templateFilePath))
          {
              using (StreamReader reader = new StreamReader(templateFilePath, Encoding.Default))
              {
                  str = reader.ReadToEnd().Replace("<$$tablestruct$$>", builder.ToString());
                  reader.Close();
              }
              return str;              
          }
          else
          {
              return null;
          }

          #endregion
      }
      #endregion

      #region 把表格式化为html对应的字符串
      /// <summary>
      /// Format DataTable to html string
      /// </summary>
      /// <param name="dt"></param>
      /// <returns></returns>
      private static string FormatDataTable(DataTable dt)
      {
          StringBuilder builder = new StringBuilder();
          builder.Append("<div class=\"styletab\"> 表名：" + dt.TableName + "</div>");
          builder.Append("<div><table border=\"0\" cellpadding=\"5\" cellspacing=\"0\" width=\"90%\">");

          //Set The Table Style
          builder.Append("<tr><td bgcolor=\"#FBFBFB\">");
          builder.Append("<table cellspacing=\"0\" cellpadding=\"5\" border=\"1\" width=\"100%\" bordercolorlight=\"#D7D7E5\" bordercolordark=\"#D3D8E0\">");
          builder.Append("<tr bgcolor=\"#F0F0F0\">");

          #region Set the table title row
          foreach (DataColumn dc in dt.Columns)
          {
              builder.Append("<td>" + dc.ColumnName + "</td>");
          }
          #endregion
          builder.Append("</tr>");

          #region
          foreach (DataRow dr in dt.Rows)
          {
              builder.Append("<tr>");
              foreach (DataColumn dc in dt.Columns)
              {
                  builder.Append("<td>" + dr[dc].ToString() + "</td>");
              }
              builder.Append("</tr>");
          }
          #endregion
          builder.Append("</table>");
          builder.Append("</td>");
          builder.Append("</tr>");
          builder.Append("</table>");
          builder.Append("</div>");
          return builder.ToString();
      }
#endregion
  }
}
