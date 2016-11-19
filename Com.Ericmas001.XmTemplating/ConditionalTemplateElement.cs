using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.Serialization;
using Com.Ericmas001.XmTemplating.VariableExtraction;

namespace Com.Ericmas001.XmTemplating
{
    [TemplateElementSerializer(typeof(ConditionalTemplateSerializer))]
    [TemplateElementVariableExtractor(typeof(ConditionalVariableExtractor))]
    public class ConditionalTemplateElement : AbstractTemplateElement
    {
        public AbstractConditionPart Condition { get; set; }
        public IEnumerable<AbstractTemplateElement> ConditionTrueElements { get; set; }
        public IEnumerable<AbstractTemplateElement> ConditionFalseElements { get; set; }

        public ConditionalTemplateElement(AbstractTemplateElement parent) : base(parent)
        {
        }
    }
}
