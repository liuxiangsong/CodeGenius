using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenius.Entity
{
    [Serializable]
  public  class TableInfo
    {
      //表名
        private string m_TableName=string.Empty;
        public string TableName
        {
            get { return m_TableName; }
            set { m_TableName = value; }
        }
        private string m_NameSpace=string.Empty;
        public string NameSpace
        {
            get { return m_NameSpace; }
            set { m_NameSpace = value; }
        }

        private string m_Folder=string.Empty;
        public string Folder
        {
            get { return m_Folder; }
            set { m_Folder = value; }
        }


      //字段集合
      public List<ColumnSchema> Columns { get; set; }
    }
}
