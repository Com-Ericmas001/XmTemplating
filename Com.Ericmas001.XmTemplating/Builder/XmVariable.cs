using System;
using System.Xml.Serialization;
using Com.Ericmas001.XmTemplating.Enums;

namespace Com.Ericmas001.XmTemplating.Builder
{

    [Serializable]
    [XmlType(TypeName = "Var")]
    public class XmVariable
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute("Default")]
        public string DefaultValue { get; set; }

        [XmlAttribute("Type")]
        public VariableTypeEnum VariableType { get; set; }
        
        public XmAttribute[] Attributes { get; set; }
        
        public string[] Values { get; set; }
    }
}
