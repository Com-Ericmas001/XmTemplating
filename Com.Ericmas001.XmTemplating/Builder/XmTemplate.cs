using System;
using System.Xml.Serialization;

namespace Com.Ericmas001.XmTemplating.Builder
{
    [Serializable]
    [XmlRoot("XmTemplate")]
    public class XmTemplate
    {
        [XmlAttribute]
        public int Version { get { return 1; } set {} }
        public XmVariable[] Arrays { get; set; }
        public XmVariable[] Variables { get; set; }

        [XmlIgnore]
        public string Template { get; set; }

        [XmlElement("Template")]
        public System.Xml.XmlCDataSection TemplateCData
        {
            get
            {
                return new System.Xml.XmlDocument().CreateCDataSection(Template);
            }
            set
            {
                Template = value.Value;
            }
        }
    }
}
