using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Paging
{
  public class PagingHelper
  {
      #region 成员变量
      private  string tableName;  //表名
      private  string fieldsToReturn = " * ";//需要返回的列
      private  string fieldNameToSort = string.Empty;//排序字段名称
      private  bool isDoCount = false;  //是否只返回总记录数
      private  int pageSize = 10;//页尺寸,就是一页显示多少条记录
      private  int pageIndex = 1;//当前的页码
      private  string strwhere = string.Empty;//检索条件(注意: 不要加 where)
      #endregion

      #region 属性对象
      /// <summary>
      /// 表名
      /// </summary>
      public string TableName
      {
          get { return tableName; }
          set { tableName = value; }
      }

      /// <summary>
      /// 需要返回的列
      /// </summary>
      public string FieldsToReturn
      {
          get { return fieldsToReturn; }
          set { fieldsToReturn = value; }
      }

      /// <summary>
      /// 排序字段名称
      /// </summary>
      public string FieldNameToSort
      {
          get { return fieldNameToSort; }
          set { fieldNameToSort = value; }
      }

      /// <summary>
      /// 页尺寸,就是一页显示多少条记录
      /// </summary>
      public int PageSize
      {
          get { return pageSize; }
          set { pageSize = value; }
      }

      /// <summary>
      /// 当前的页码
      /// </summary>
      public int PageIndex
      {
          get { return pageIndex; }
          set { pageIndex = value; }
      }
       

      /// <summary>
      /// 检索条件(注意: 不要加 where)
      /// </summary>
      public string StrWhere
      {
          get { return strwhere; }
          set { strwhere = value; }
      }
      #endregion

      #region 构造函数
      public PagingHelper(string strwhere,int pageIndex)
      {
          this.StrWhere = strwhere;
          this.PageIndex = pageIndex;
      }

      public PagingHelper(string tableName, string fieldsToReturn ,int pageIndex ,
              string fieldNameToSort ,int pageSize , string strwhere )
      {
          this.TableName = tableName; 

          this.FieldsToReturn = fieldsToReturn;
          this.FieldNameToSort = fieldNameToSort;
          this.PageSize = pageSize;
          this.PageIndex = pageIndex;

          this.StrWhere = strwhere;
      }

      #endregion

      /// <summary>
      /// 取得总记录条数
      /// </summary>
      /// <returns></returns>
      public int GetRecordCount()
      {
          this.isDoCount = true; 
          string sqlString = PrepareSqlString();
          return (int)SQLHelper.GetExecuteScalar(sqlString);
      }

      /// <summary>
      /// 取得页面的数据
      /// </summary>
      /// <returns></returns>
      public DataTable GetDataTable()
      {
          this.isDoCount=false;
          string sqlString = PrepareSqlString();
          return  SQLHelper.GetDataTable(sqlString);
      }

      private string PrepareSqlString()
      {
          string sqlString = string.Empty;
          if (this.isDoCount)
          { 
              sqlString = string.Format("select count(1) as Total from [{0}] ", this.TableName);
              if (!string.IsNullOrEmpty(this.StrWhere))
              {
                  sqlString += string.Format("Where {0} ", this.StrWhere);
              }
          }
          else
          {
              sqlString = string.Format("select top {0} {1} from [{2}] ", this.PageSize, this.FieldsToReturn, this.TableName);
              string strOrder = string.Format(" order by [{0}] ", this.FieldNameToSort);
              if (this.PageIndex == 1)
              {
                  if (!string.IsNullOrEmpty(this.StrWhere))
                  {
                      sqlString += string.Format(" Where {0} ", this.StrWhere);
                  }
              }
              else
              {
                  if (!string.IsNullOrEmpty(this.StrWhere))
                  {
                      sqlString += string.Format(" Where not exists((select * from (select top {1} [{0}] from [{2}] where {4} {3}) as temp where {2}.{0}=temp.{0})) and {4} {3}",
                          this.FieldNameToSort, (this.PageIndex - 1) * this.PageSize, this.TableName, strOrder, this.StrWhere);
                  }
                  else
                  {
                      sqlString += string.Format(" Where not exists((select * from (select top {1} [{0}] from [{2}] {3}) as temp where {2}.{0}=temp.{0})) {3}",
                          this.FieldNameToSort, (this.PageIndex - 1) * this.PageSize, this.TableName, strOrder);
                  }
              }
          }
          return sqlString;
      }
  }
}
