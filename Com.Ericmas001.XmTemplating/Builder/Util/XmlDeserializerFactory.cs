using System;
using System.IO;
using System.Xml.Serialization;

namespace Com.Ericmas001.XmTemplating.Builder.Util
{
    public static class XmlDeserializerFactory
    {
        [Serializable]
        [XmlRoot("XmTemplate")]
        public class DummyTemplate
        {
            [XmlAttribute]
            public int Version { get; set; }
        }
        public static XmTemplate Deserialize(string path)
        {
            int version = 0;

            using (var sr = File.OpenText(path))
            {
                var dt = (DummyTemplate)new XmlSerializer(typeof(DummyTemplate)).Deserialize(sr);
                version = dt.Version;
            }

            using (var sr = File.OpenText(path))
            {
                switch (version)
                {
                    case 1:
                    {
                        XmTemplate jclTemplateElement = (XmTemplate) new XmlSerializer(typeof (XmTemplate)).Deserialize(sr);
                        return jclTemplateElement;
                    }
                    default:
                    {
                        throw new NotImplementedException("This version of XmTemplate ( "+version+" ) is not supported !!");
                    }
                }
            }
        }
    }
}
