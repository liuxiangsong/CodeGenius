﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenius.Entity
{
    [Serializable]
    public class RoleSchema : DBObjectSchema
    {
    }

    [Serializable]
    public class RoleSchemaCollection : List<RoleSchema>
    {
    }
}
