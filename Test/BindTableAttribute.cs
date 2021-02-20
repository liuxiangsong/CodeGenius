using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    /// <summary>
    /// 数据表名绑定特性
    /// </summary> 
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class BindTableAttribute : Attribute
    {
        /// <summary>
        /// 初始化对象
        /// </summary>
        public BindTableAttribute()
        {
        }
        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <param name="name">数据表名</param>
        public BindTableAttribute(string tableName)
        {
            m_TableName = tableName;
        }

        private string m_TableName = null;

        /// <summary>
        /// 数据表名
        /// </summary>
        public string TableName
        {
            get
            {
                return m_TableName;
            }
        }

    }
}
