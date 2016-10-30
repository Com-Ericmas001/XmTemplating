using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.Conditions;

namespace Com.Ericmas001.XmTemplating
{
    public class DefineTemplateElement : AbstractTemplateElement
    {
        public VariableConditionPart Variable { get; set; }
        public IEnumerable<AbstractTemplateElement> Elements { get; set; }
        public bool IsArray { get; set; }

        public DefineTemplateElement(AbstractTemplateElement parent) : base(parent)
        {
        }
    }
}
