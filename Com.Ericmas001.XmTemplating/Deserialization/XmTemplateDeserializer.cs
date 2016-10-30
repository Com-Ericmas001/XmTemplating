using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Com.Ericmas001.XmTemplating.Deserialization.Util;
using Com.Ericmas001.XmTemplating.Enums;

namespace Com.Ericmas001.XmTemplating.Deserialization
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class XmTemplateDeserializer : AbstractTemplateDeserializer<XmTemplateElement>
    {
        private XmTemplateDeserializer()
        {
            
        }

        public override XmTemplateElement Deserialize(TemplateTokenizer tokenizer, AbstractTemplateElement root)
        {
            var result = new XmTemplateElement {TemplateSource = tokenizer.CurrentTemplate};
            result.Elements = FindElements(result, tokenizer).ToArray();
            return result;
        }

        public static XmTemplateElement Deserialize(string template, TemplateDeserializationParms parms = null)
        {
            var d = new XmTemplateDeserializer();
            d.Initialize(parms ?? new TemplateDeserializationParms(), TemplateCommandEnum.Unknown);
            return d.Deserialize(new TemplateTokenizer(template), null);
        }
    }
}
