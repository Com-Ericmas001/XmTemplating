using System;
using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.XmTemplating.Enums;

namespace Com.Ericmas001.XmTemplating.Attributes
{
    public class TemplateElementVariableExtractorAttribute : Attribute
    {
        public Type VariableExtractor { get; set; }

        public TemplateElementVariableExtractorAttribute(Type varExtractor, bool useClones = true)
        {
            VariableExtractor = varExtractor;
        }
    }
}
