using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.Conditions.Util;
using Com.Ericmas001.XmTemplating.Deserialization.Util;

namespace Com.Ericmas001.XmTemplating.Deserialization
{
    public class DefineTemplateDeserializer : AbstractTemplateDeserializer<DefineTemplateElement>
    {
        private readonly bool m_IsArray;

        public DefineTemplateDeserializer(TemplateDeserializationParms parms, bool isArray) : base(parms)
        {
            m_IsArray = isArray;
        }

        public override DefineTemplateElement Deserialize(TemplateTokenizer tokenizer, AbstractTemplateElement root)
        {
            var result = new DefineTemplateElement(root);

            tokenizer.AdvanceUntilChar(' ');
            var stuff = tokenizer.AdvanceUntilChar('>').Trim();

            result.Variable = (VariableConditionPart) ConditionDeserializer.Deserialize(stuff, new Dictionary<string, AbstractConditionPart>());
            result.IsArray = m_IsArray;
            tokenizer.Advance();
            result.Elements = FindElements(result, tokenizer, "/DEFINE").ToArray();
            tokenizer.AdvanceUntilChar('>');
            return result;
        }
    }
}
