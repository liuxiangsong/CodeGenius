using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGenius
{
    public class SearchInfo
    {

        #region 构造函数
        //public SearchInfo() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="fieldValue">字段的值</param>
        /// <param name="sqlOperator">字段的Sql操作符号</param>
        /// <param name="count">集合中同一字段名重復的次數</param>
        public SearchInfo(string fieldName, object fieldValue, SqlOperator sqlOperator, int count = 0)
            : this(fieldName, fieldValue, sqlOperator, true,count)
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="fieldValue">字段的值</param>
        /// <param name="sqlOperator">字段的Sql操作符号</param>
        /// <param name="excludeIfEmpty">如果字段为空或者Null则不作为查询条件</param>
        /// <param name="count">集合中同一字段名重復的次數</param>
        public SearchInfo(string fieldName, object fieldValue, SqlOperator sqlOperator, bool isExcludeEmpty,int count=0)
        {
            this.fieldName = fieldName;
            this.fieldValue = fieldValue;
            this.sqlOperator = sqlOperator;
            this.isExcludeEmpty = isExcludeEmpty;
            this.Count = count;
        }
        #endregion

        #region 字段属性
        private int count;
        private string fieldName;
        private object fieldValue;
        private SqlOperator sqlOperator;
        private bool isExcludeEmpty = false;

        /// <summary>
        /// 集合中同一字段名的個數
        /// </summary>
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName
        {
            get { return fieldName; }
            set { fieldName = value; }
        }

        /// <summary>
        /// 字段的值
        /// </summary>
        public object FieldValue
        {
            get { return fieldValue; }
            set { fieldValue = value; }
        }

        /// <summary>
        /// 字段的Sql操作符号
        /// </summary>
        public SqlOperator SqlOperator
        {
            get { return sqlOperator; }
            set { sqlOperator = value; }
        }

        /// <summary>
        /// 如果字段为空或者Null则不作为查询条件
        /// </summary>
        public bool IsExcludeEmpty
        {
            get { return isExcludeEmpty; }
            set { isExcludeEmpty = value; }
        }
        #endregion

    }
}
