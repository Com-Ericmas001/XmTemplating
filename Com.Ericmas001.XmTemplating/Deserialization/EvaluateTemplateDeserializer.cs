using System.Collections.Generic;
using Com.Ericmas001.Common;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.Conditions.Util;
using Com.Ericmas001.XmTemplating.Deserialization.Util;

namespace Com.Ericmas001.XmTemplating.Deserialization
{
    public class EvaluateTemplateDeserializer : AbstractTemplateDeserializer<EvaluateTemplateElement>
    {
        public EvaluateTemplateDeserializer(TemplateDeserializationParms parms) : base(parms)
        {
        }

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
