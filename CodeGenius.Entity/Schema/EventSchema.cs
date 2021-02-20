using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenius.Entity
{
    [Serializable]
    public class EventSchema : DBObjectSchema
    {
    }

    [Serializable]
    public class EventSchemaCollection : List<EventSchema>
    {
    }
}
