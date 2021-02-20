using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenius.Entity
{
    [Serializable]
    public class ViewSchema : TableSchema
    {
    }

    [Serializable]
    public class ViewSchemaCollection : List<ViewSchema>
    {
    }
}
