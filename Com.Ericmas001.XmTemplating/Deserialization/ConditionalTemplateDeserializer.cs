using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.Common;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.Conditions.Util;
using Com.Ericmas001.XmTemplating.Deserialization.Util;

namespace Com.Ericmas001.XmTemplating.Deserialization
{
    public class ConditionalTemplateDeserializer : AbstractTemplateDeserializer<ConditionalTemplateElement>
    {
        public ConditionalTemplateDeserializer(TemplateDeserializationParms parms) : base(parms)
        {
        }

        public override ConditionalTemplateElement Deserialize(TemplateTokenizer tokenizer, AbstractTemplateElement root)
        {
            var result = new ConditionalTemplateElement(root)
            {
                Condition = ConditionDeserializer.Deserialize(tokenizer.AdvanceUntilChar(']').InfoAfter("[", int.MaxValue), new Dictionary<string, AbstractConditionPart>())
            };

            tokenizer.AdvanceUntilChar('>');
            tokenizer.Advance();
            result.ConditionTrueElements = FindElements(result, tokenizer, "/IF", ":ELSE:").ToArray();
            var command = tokenizer.AdvanceUntilChar('>').ToUpper();

            if (command != ":ELSE:") 
                return result;

            tokenizer.Advance();
            result.ConditionFalseElements = FindElements(result, tokenizer, "/IF", ":ELSE:").ToArray();
            tokenizer.AdvanceUntilChar('>');
            return result;
        }
    }
}
