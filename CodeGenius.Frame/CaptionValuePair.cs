using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenius.Frame
{
    public class CaptionValuePair
    {
        public string Caption { get; set; }
        public object Value { get; set; }

        //public CaptionValuePair()
        //{
        //}
        public CaptionValuePair(string caption, object value)
        {
            this.Caption = caption;
            this.Value = value;
        }

        public override string ToString()
        {
            return Caption;
        }
    }
}
