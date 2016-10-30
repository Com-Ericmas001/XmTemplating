using System.Collections.Generic;
using Com.Ericmas001.Common;
using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.Conditions.Util;
using Com.Ericmas001.XmTemplating.Deserialization.Util;
using Com.Ericmas001.XmTemplating.Enums;

namespace Com.Ericmas001.XmTemplating.Deserialization
{
    [TemplateCommand(TemplateCommandEnum.Eval)]
    public class EvaluateTemplateDeserializer : AbstractTemplateDeserializer<EvaluateTemplateElement>
    {
        public override EvaluateTemplateElement Deserialize(TemplateTokenizer tokenizer, AbstractTemplateElement root)
        {
            var result = new EvaluateTemplateElement(root)
            {
                Expression = ConditionDeserializer.Deserialize(tokenizer.AdvanceUntilChar(']').InfoAfter("[", int.MaxValue), new Dictionary<string, AbstractConditionPart>())
            };

            tokenizer.AdvanceUntilChar('>');
            return result;
        }
    }
}
