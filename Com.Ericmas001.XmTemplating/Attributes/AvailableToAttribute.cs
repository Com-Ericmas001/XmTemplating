using System;
using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.XmTemplating.Enums;

namespace Com.Ericmas001.XmTemplating.Attributes
{
    public class AvailableToAttribute : Attribute
    {
        public IEnumerable<VariableTypeEnum> Types { get; private set; }
        public AvailableToAttribute(VariableTypeEnum type, params VariableTypeEnum[] types)
        {
            Types = new []{type}.Union(types).ToArray();
        }
    }
}
