using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using System.Data.SqlClient;

namespace LibraryGenius
{
    public class SearchCondition
    {
        private List<SearchInfo> m_SearchInfo = new List<SearchInfo>();

        /// <summary>
        /// 为查询添加条件
        /// </summary>
        /// <param name="fielName">字段名称</param>
        /// <param name="fieldValue">字段值</param>
        /// <param name="sqlOperator">SqlOperator枚举类型</param>
        /// <returns>增加条件后的Hashtable</returns>
        public SearchCondition AddCondition(string fielName, object fieldValue, SqlOperator sqlOperator)
        {
            int count = m_SearchInfo.FindAll(a => a.FieldName == fielName).Count ;
            this.m_SearchInfo.Add(new SearchInfo(fielName, fieldValue, sqlOperator, count));
            return this;
        }

        /// <summary>
        /// 为查询添加条件
        /// </summary>
        /// <param name="fielName">字段名称</param>
        /// <param name="fieldValue">字段值</param>
        /// <param name="sqlOperator">SqlOperator枚举类型</param>
        /// <param name="isExcludeEmpty">如果字段为空或者Null则不作为查询条件</param>
        /// <returns></returns>
        public SearchCondition AddCondition(string fielName, object fieldValue, SqlOperator sqlOperator, bool isExcludeEmpty)
        {
            int count = m_SearchInfo.FindAll(a => a.FieldName == fielName).Count ;
            this.m_SearchInfo.Add(new SearchInfo(fielName, fieldValue, sqlOperator, isExcludeEmpty, count));
            return this;
        }


        /// <summary>
        /// 生成非參數化的條件語句
        /// </summary>
        /// <returns></returns>
        public string BuildConditionString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (SearchInfo info in this.m_SearchInfo)
            {
                //如果选择IsExcludeEmpty为True,并且该字段为空值的话,跳过
                if (info.IsExcludeEmpty && string.IsNullOrEmpty(info.FieldValue.ToString())) continue;

                if (info.SqlOperator == SqlOperator.Like)
                {
                    sb.AppendFormat(" AND {0} like '{1}'", info.FieldName, string.Format("%{0}%", info.FieldValue));
                }
                else
                {
                    sb.AppendFormat(" AND {0} {1} '{2}'", info.FieldName,
                        this.ConvertSqlOperator(info.SqlOperator), info.FieldValue);
                }
            }
            return (sb.Length > 3) ? sb.ToString().Substring(4) : null;
        }

        public void BuildCondition(out string condition, out List<SqlParameter> parameterList)
        {
            parameterList = new List<SqlParameter>();
            StringBuilder sb = new StringBuilder();

            foreach (SearchInfo info in this.m_SearchInfo)
            {
                //如果选择IsExcludeEmpty为True,并且该字段为空值的话,跳过
                if (info.IsExcludeEmpty && string.IsNullOrEmpty(info.FieldValue.ToString())) continue;

                sb.AppendFormat(" AND {0} {1} @{2}", info.FieldName, this.ConvertSqlOperator(info.SqlOperator),GetParameterName( info.FieldName ,info.Count ));

                if (info.SqlOperator == SqlOperator.Like)
                {
                    parameterList.Add(new SqlParameter()
                    {
                        ParameterName = string.Format("@{0}", GetParameterName(info.FieldName ,info.Count )),
                        Value = string.Format("%{0}%", info.FieldValue)
                    });
                }
                else
                {
                    parameterList.Add(new SqlParameter()
                    {
                        ParameterName = string.Format("@{0}",GetParameterName( info.FieldName , info.Count )),
                        Value = info.FieldValue
                    });
                }
            }
            condition = (sb.Length > 3) ? sb.ToString().Substring(4) : null;
        }

        /// <summary>
        /// 取得參數的名稱
        /// </summary>
        /// <param name="fieldName">字段名称</param> 
        /// <param name="count">集合中同一字段名重復的次數</param>
        /// <returns></returns>
        private string GetParameterName(string fieldName, int count)
        {
            if (count < 1)
                return fieldName;
            else
                return fieldName + count.ToString();
        }

        #region 转换枚举类型为对应的Sql语句操作符号
        /// <summary>
        /// 转换枚举类型为对应的Sql语句操作符号
        /// </summary>
        /// <param name="sqlOperator">SqlOperator枚举对象</param>
        /// <returns>转化成对应的Sql语句操作符号（如 ">" "<>" ">=")</returns>
        private string ConvertSqlOperator(SqlOperator sqlOperator)
        {
            string stringOperator = " = ";
            switch (sqlOperator)
            {
                case SqlOperator.Equal:
                    stringOperator = " = "; break;
                case SqlOperator.LessThan:
                    stringOperator = " < "; break;
                case SqlOperator.LessThanOrEqual:
                    stringOperator = " <= "; break;
                case SqlOperator.Like:
                    stringOperator = " Like "; break;
                case SqlOperator.MoreThan:
                    stringOperator = " > "; break;
                case SqlOperator.MoreThanOrEqual:
                    stringOperator = " >= "; break;
                case SqlOperator.NotEqual:
                    stringOperator = " <> "; break;
            }
            return stringOperator;
        }
        #endregion

    }
}
