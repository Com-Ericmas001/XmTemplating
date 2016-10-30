using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.Conditions;

namespace Com.Ericmas001.XmTemplating
{
    public class EnumeratorTemplateElement : AbstractTemplateElement
    {
        public AbstractConditionPart EnumerationCondition { get; set; }
        public IEnumerable<AbstractTemplateElement> Elements { get; set; }

        public EnumeratorTemplateElement(AbstractTemplateElement parent) : base(parent)
        {
        }
    }
}
