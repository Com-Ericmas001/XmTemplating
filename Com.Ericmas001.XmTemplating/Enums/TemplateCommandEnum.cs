using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ericmas001.XmTemplating.Attributes;

namespace Com.Ericmas001.XmTemplating.Enums
{
    public enum TemplateCommandEnum
    {
        Unknown,

        [TemplateCommandName("IF")]
        If,

        [TemplateCommandName("FOREACH")]
        Foreach,
        
        [TemplateCommandName("FOR")]
        For,

        [TemplateCommandName("EVAL")]
        Eval,

        [TemplateCommandName("DEFINE")]
        Define,

        [TemplateCommandName("DEFINE_ARRAY")]
        DefineArray,

        [TemplateCommandName("BR")]
        LineBreak
    }
}
