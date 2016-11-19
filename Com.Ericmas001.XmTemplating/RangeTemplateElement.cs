using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.Serialization;
using Com.Ericmas001.XmTemplating.VariableExtraction;

namespace Com.Ericmas001.XmTemplating
{
    [TemplateElementSerializer(typeof(RangeTemplateSerializer))]
    [TemplateElementVariableExtractor(typeof(RangeVariableExtractor))]
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
