using System;
using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.XmTemplating.Enums;

namespace Com.Ericmas001.XmTemplating.Attributes
{
    public class TemplateElementSerializerAttribute : Attribute
    {
        public Type Serializer { get; set; }
        public bool UseClones { get; set; }

        public TemplateElementSerializerAttribute(Type serializer, bool useClones = true)
        {
            Serializer = serializer;
            UseClones = useClones;
        }
    }
}
