using System;
using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Deserialization.Util;
using Com.Ericmas001.XmTemplating.Enums;

namespace Com.Ericmas001.XmTemplating.Deserialization
{
    [TemplateCommand(TemplateCommandEnum.LineBreak)]
    public class NewLineTemplateDeserializer : AbstractTemplateDeserializer<StaticTemplateElement>
    {
        public override StaticTemplateElement Deserialize(TemplateTokenizer tokenizer, AbstractTemplateElement root)
        {
            var result = new StaticTemplateElement(root)
            {
                Content = Environment.NewLine
            };

            tokenizer.AdvanceUntilChar('>');
            return result;
        }
    }
}
