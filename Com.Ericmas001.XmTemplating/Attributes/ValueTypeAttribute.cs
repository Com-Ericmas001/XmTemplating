using System;

namespace Com.Ericmas001.XmTemplating.Attributes
{
    public class ValueTypeAttribute : Attribute
    {
        public Type ValueType { get; private set; }
        public ValueTypeAttribute(Type type)
        {
            ValueType = type;
        }
    }
}
