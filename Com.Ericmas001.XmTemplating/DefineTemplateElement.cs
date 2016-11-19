using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.Serialization;

namespace Com.Ericmas001.XmTemplating
{
    [TemplateElementSerializer(typeof(DefineTemplateSerializer),false)]
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
