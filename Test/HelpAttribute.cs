using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
        [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)] 

    class HelpAttribute : Attribute
    {
        public HelpAttribute(String Descrition_in)
        {
            this.description = Descrition_in;
            
        }
        protected String description;
        public String Description
        {
            get
            {
                return this.description;
            }
             
        }
    }
}
