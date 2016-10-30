using System;
using Com.Ericmas001.XmTemplating.Deserialization.Util;

namespace Com.Ericmas001.XmTemplating.Deserialization
{
    public class NewLineTemplateDeserializer : AbstractTemplateDeserializer<StaticTemplateElement>
    {
        public NewLineTemplateDeserializer(TemplateDeserializationParms parms) : base(parms)
        {
        }

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
