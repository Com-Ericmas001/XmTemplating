using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Serialization;

namespace Com.Ericmas001.XmTemplating
{
    [TemplateElementSerializer(typeof(StaticTemplateSerializer))]
    public class StaticTemplateElement : AbstractTemplateElement
    {
        public string Content { get; set; }

        public StaticTemplateElement(AbstractTemplateElement parent) : base(parent)
        {
        }
    }
}
