using System;
using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.XmTemplating.Enums;

namespace Com.Ericmas001.XmTemplating.Attributes
{
    public class TemplateElementAttribute : Attribute
    {
        public Type Element { get; set; }
        public bool UseClones { get; set; }

        public TemplateElementAttribute(Type element, bool useClones = true)
        {
            Element = element;
            UseClones = useClones;
        }
    }
}
