using System;
using System.Collections.Generic;
using System.Text;

namespace Stx.Shared.Common
{
    public class ParmStr
    {
        public ParmStr()
        {

        }
        public ParmStr(string value, string text)
        {
            Value = value;
            Text = text;
        }

        public string Value { get; set;}
        public string Text { get; set; } = "";
    }
}
