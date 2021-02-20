using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CodeGenius.Entity 
{
    [Serializable]
    public class DataBaseSchema : DBObjectSchema
    {
        [Description("Owner")]
        public string Owner { get; set; }

        [Description("Status")]
        public string Status { get; set; }

        [Description("CollationName")]
        public string CollationName { get; set; }

        [Description("创建时间")]
        public DateTime CreateDate { get; set; }

        protected string sqlConnectionString = string.Empty;
        internal readonly TableSchemaCollection tables = new TableSchemaCollection();
        internal readonly ViewSchemaCollection views = new ViewSchemaCollection();

        /// <summary>
        /// 数据库链接字符串
        /// </summary>
        public string ConnectionString
        {
            get { return sqlConnectionString; }
            set { sqlConnectionString = (value ?? string.Empty).Trim(); }
        }

        /// <summary>
        /// 数据库 的 表对象 集合；
        /// </summary>
        public TableSchemaCollection Tables
        {
            get { return tables; }
            set
            {
                if (value != tables)
                {
                    tables.Clear();
                    if (value != null && value.Count > 0)
                        tables.AddRange(value);
                }
            }
        }

        /// <summary>
        /// 数据库 的 视图对象 集合；
        /// </summary>
        public ViewSchemaCollection Views
        {
            get { return views; }
            set
            {
                if (value != views)
                {
                    views.Clear();
                    if (value != null && value.Count > 0)
                        views.AddRange(value);
                }
            }
        }

        public int TableCount
        {
            get { return Tables.Count; }
        }

        public int ViewCount
        {
            get { return Views.Count; }
        }
    }

    [Serializable]
    public class DataBaseSchemaCollection : List<DataBaseSchema>
    {
    }

}
