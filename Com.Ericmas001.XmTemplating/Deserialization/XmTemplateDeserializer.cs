using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Com.Ericmas001.XmTemplating.Deserialization.Util;

namespace Com.Ericmas001.XmTemplating.Deserialization
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class XmTemplateDeserializer : AbstractTemplateDeserializer<XmTemplateElement>
    {
        public XmTemplateDeserializer(TemplateDeserializationParms parms = null) : base(parms ?? new TemplateDeserializationParms())
        {
        }

        public XmTemplateElement Deserialize(string template)
        {
            return Deserialize(new TemplateTokenizer(template), null);
        }

        public override XmTemplateElement Deserialize(TemplateTokenizer tokenizer, AbstractTemplateElement root)
        {
            var result = new XmTemplateElement {TemplateSource = tokenizer.CurrentTemplate};
            result.Elements = FindElements(result, tokenizer).ToArray();
            return result;
        }
    }
}
