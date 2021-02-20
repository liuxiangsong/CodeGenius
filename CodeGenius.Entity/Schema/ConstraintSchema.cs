using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenius.Entity
{
    [Serializable]
   public class ConstraintSchema : DBObjectSchema
    {
    }

    [Serializable]
   public class ConstraintSchemaCollection : List<ConstraintSchema>
   {
   }
}
