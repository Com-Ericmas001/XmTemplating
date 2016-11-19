using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.Serialization;
using Com.Ericmas001.XmTemplating.VariableExtraction;

namespace Com.Ericmas001.XmTemplating
{
    [TemplateElementSerializer(typeof(DefineTemplateSerializer), false)]
    [TemplateElementVariableExtractor(typeof(DefineVariableExtractor), false)]
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
