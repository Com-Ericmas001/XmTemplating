using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Serialization;
using Com.Ericmas001.XmTemplating.VariableExtraction;

namespace Com.Ericmas001.XmTemplating
{
    [TemplateElementSerializer(typeof(StaticTemplateSerializer))]
    [TemplateElementVariableExtractor(typeof(StaticVariableExtractor))]
    public class StaticTemplateElement : AbstractTemplateElement
    {
        public string Content { get; set; }

        public StaticTemplateElement(AbstractTemplateElement parent) : base(parent)
        {
        }
    }
}
