using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CodeGenius.Entity
{
    [Serializable]
   public class TriggerSchema : DBObjectSchema
    {
        [Description("创建时间")]
        public DateTime CreateDate { get; set; }

        [Description("修改时间")]
        public DateTime ModifyDate { get; set; }
    }

    [Serializable]
   public class TriggerSchemaCollection : List<TriggerSchema>
   {
   }
}
