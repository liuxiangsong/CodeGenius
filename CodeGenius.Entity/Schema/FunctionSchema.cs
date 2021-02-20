using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenius.Entity
{
    [Serializable]
    public class FunctionSchema : DBObjectSchema
    {
    }

    [Serializable]
    public class FunctionSchemaCollection : List<FunctionSchema>
    {
    }
}
