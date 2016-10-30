using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.Conditions;

namespace Com.Ericmas001.XmTemplating
{
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
