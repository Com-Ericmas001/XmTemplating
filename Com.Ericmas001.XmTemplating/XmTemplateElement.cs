using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Serialization;

namespace Com.Ericmas001.XmTemplating
{
    [TemplateElementSerializer(typeof(XmTemplateSerializer))]
    public class XmTemplateElement : AbstractTemplateElement
    {
        public IEnumerable<AbstractTemplateElement> Elements { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string TemplateSource { get; set; }

        public XmTemplateElement() : base(null)
        {
        }
    }
}
