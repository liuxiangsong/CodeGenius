using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CodeGenius.Entity
{
    [Serializable]
   public class KeySchema : DBObjectSchema
    {
       [Description("键的类型")]
       public KeyType KeyType { get; set; }
    }

   public class KeySchemaCollection : List<KeySchema>
   {
   }

    /// <summary>
    /// 表示一个数据键的类型的枚举
    /// </summary>
    [Serializable]
    public enum KeyType
    {
        Primary,
        Foreigne
    }  
}
