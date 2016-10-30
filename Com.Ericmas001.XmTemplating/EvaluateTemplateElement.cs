using Com.Ericmas001.XmTemplating.Conditions;

namespace Com.Ericmas001.XmTemplating
{
    public class EvaluateTemplateElement : AbstractTemplateElement
    {
        public AbstractConditionPart Expression { get; set; }

        public EvaluateTemplateElement(AbstractTemplateElement parent) : base(parent)
        {
        }
    }
}
