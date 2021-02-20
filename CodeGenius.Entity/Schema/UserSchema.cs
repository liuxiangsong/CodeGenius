using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenius.Entity
{
    [Serializable]
    public class UserSchema : DBObjectSchema
    {
    }

    [Serializable]
    public class UserSchemaCollection : List<UserSchema>
    {
    }
}
