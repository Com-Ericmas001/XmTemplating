using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.Serialization;

namespace Com.Ericmas001.XmTemplating
{
    [TemplateElementSerializer(typeof(EnumeratorTemplateSerializer))]
    public class EnumeratorTemplateElement : AbstractTemplateElement
    {
        public AbstractConditionPart EnumerationCondition { get; set; }
        public IEnumerable<AbstractTemplateElement> Elements { get; set; }

        public EnumeratorTemplateElement(AbstractTemplateElement parent) : base(parent)
        {
        }
    }
}
