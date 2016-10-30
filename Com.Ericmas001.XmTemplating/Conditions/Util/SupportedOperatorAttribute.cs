using System;
using System.Collections.Generic;

namespace Com.Ericmas001.XmTemplating.Conditions.Util
{
    public class SupportedOperatorAttribute : Attribute
    {
        public IEnumerable<string> Operators { get; private set; }  

        public SupportedOperatorAttribute(params string[] operators)
        {
            Operators = operators;
        }
    }
}
