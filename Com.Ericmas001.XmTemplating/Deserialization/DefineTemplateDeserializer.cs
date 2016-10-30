using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.Conditions.Util;
using Com.Ericmas001.XmTemplating.Deserialization.Util;
using Com.Ericmas001.XmTemplating.Enums;

namespace Com.Ericmas001.XmTemplating.Deserialization
{
    [TemplateCommand(TemplateCommandEnum.Define, TemplateCommandEnum.DefineArray)]
    public class DefineTemplateDeserializer : AbstractTemplateDeserializer<DefineTemplateElement>
    {
        public override DefineTemplateElement Deserialize(TemplateTokenizer tokenizer, AbstractTemplateElement root)
        {
            var result = new DefineTemplateElement(root);

            tokenizer.AdvanceUntilChar(' ');
            var stuff = tokenizer.AdvanceUntilChar('>').Trim();

            result.Variable = (VariableConditionPart) ConditionDeserializer.Deserialize(stuff, new Dictionary<string, AbstractConditionPart>());
            result.IsArray = Command == TemplateCommandEnum.DefineArray;
            tokenizer.Advance();
            result.Elements = FindElements(result, tokenizer, "/DEFINE").ToArray();
            tokenizer.AdvanceUntilChar('>');
            return result;
        }
    }
}
