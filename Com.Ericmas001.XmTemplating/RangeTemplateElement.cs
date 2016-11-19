using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.Serialization;

namespace Com.Ericmas001.XmTemplating
{
    [TemplateElementSerializer(typeof(RangeTemplateSerializer))]
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
