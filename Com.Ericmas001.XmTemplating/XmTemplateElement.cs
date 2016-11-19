using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Serialization;
using Com.Ericmas001.XmTemplating.VariableExtraction;

namespace Com.Ericmas001.XmTemplating
{
    [TemplateElementSerializer(typeof(XmTemplateSerializer))]
    [TemplateElementVariableExtractor(typeof(VariableExtractor))]
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
