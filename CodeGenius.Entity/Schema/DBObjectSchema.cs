using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CodeGenius.Entity
{
    [Serializable]
   public class DBObjectSchema
    {
       [Description("名称")]
       public string Name { get; set; }

       [Description("保存其他自定义对象")]
       public object Tag { get; set; }
    }
}
