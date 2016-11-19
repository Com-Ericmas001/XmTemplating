using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.Serialization;

namespace Com.Ericmas001.XmTemplating
{
    [TemplateElementSerializer(typeof(EvaluateTemplateSerializer))]
    public class EvaluateTemplateElement : AbstractTemplateElement
    {
        public AbstractConditionPart Expression { get; set; }

        public EvaluateTemplateElement(AbstractTemplateElement parent) : base(parent)
        {
        }
    }
}
