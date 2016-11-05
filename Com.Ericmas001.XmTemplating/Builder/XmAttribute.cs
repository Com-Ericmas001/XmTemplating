using System.Xml.Serialization;
using Com.Ericmas001.XmTemplating.Enums;

namespace Com.Ericmas001.XmTemplating.Builder
{
    [XmlType(TypeName = "Att")]
    public class XmAttribute
    {
        [XmlAttribute]
        public VarAttributeEnum Name { get; set; }

        [XmlAttribute]
        public string Value { get; set; }
    }
}
