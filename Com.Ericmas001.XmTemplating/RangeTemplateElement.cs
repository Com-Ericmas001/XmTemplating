using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.Conditions;

namespace Com.Ericmas001.XmTemplating
{
    public class RangeTemplateElement : AbstractTemplateElement
    {
        public VariableConditionPart Variable { get; set; }
        public AbstractConditionPart Minimum { get; set; }
        public AbstractConditionPart Maximum { get; set; }
        public bool InludeMaximum { get; set; }
        public IEnumerable<AbstractTemplateElement> Elements { get; set; }

        public RangeTemplateElement(AbstractTemplateElement parent) : base(parent)
        {
        }
    }
}
