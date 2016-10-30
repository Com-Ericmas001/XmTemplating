using System;
using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.XmTemplating.Enums;

namespace Com.Ericmas001.XmTemplating.Attributes
{
    public class TemplateCommandAttribute : Attribute
    {
        public IEnumerable<TemplateCommandEnum> Commands { get; } 
        public TemplateCommandAttribute(TemplateCommandEnum command, params TemplateCommandEnum[] aliases)
        {
            Commands = new[] {command}.Union(aliases).ToArray();
        }
    }
}
