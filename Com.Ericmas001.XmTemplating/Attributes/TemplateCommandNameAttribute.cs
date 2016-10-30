using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.Ericmas001.XmTemplating.Attributes
{
    public class TemplateCommandNameAttribute : Attribute
    {
        public IEnumerable<string> CommandNames { get; } 
        public TemplateCommandNameAttribute(string command, params string[] aliases)
        {
            CommandNames = new[] {command.ToUpper()}.Union(aliases.Select(x => x.ToUpper())).ToArray();
        }
    }
}
