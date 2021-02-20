using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace CodeGenius.Entity
{
    [Serializable]
    public abstract class DataEngineSchema : DBObjectSchema
    {
        protected string connectionString = string.Empty;

        ///// <summary>
        // /// 数据库类型的唯一标识名称，该名称的命名没有规范，但不能冲突；
        // /// </summary>
        // public abstract string Key { get; }
        /// <summary>
        /// 当前数据库引擎的链接字符串；
        /// </summary>
        public virtual string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = (value ?? string.Empty).Trim(); }
        }


        protected DataEngineSchema() { }
        protected DataEngineSchema(string initializedConnectionString)
        {
            connectionString = initializedConnectionString;
        }

        public DataBaseSchemaCollection DataBases { get; set; }
    }
}
