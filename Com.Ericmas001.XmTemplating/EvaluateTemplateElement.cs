using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.Serialization;
using Com.Ericmas001.XmTemplating.VariableExtraction;

namespace Com.Ericmas001.XmTemplating
{
    [TemplateElementSerializer(typeof(EvaluateTemplateSerializer))]
    [TemplateElementVariableExtractor(typeof(EvaluateVariableExtractor))]
    public class EvaluateTemplateElement : AbstractTemplateElement
    {
        public AbstractConditionPart Expression { get; set; }

        public EvaluateTemplateElement(AbstractTemplateElement parent) : base(parent)
        {
        }
    }
}
