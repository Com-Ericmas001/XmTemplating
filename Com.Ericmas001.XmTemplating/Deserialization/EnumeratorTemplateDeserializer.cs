﻿using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.Common;
using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.Conditions.Util;
using Com.Ericmas001.XmTemplating.Deserialization.Util;
using Com.Ericmas001.XmTemplating.Enums;

namespace Com.Ericmas001.XmTemplating.Deserialization
{
    [TemplateCommand(TemplateCommandEnum.Foreach)]
    public class EnumeratorTemplateDeserializer : AbstractTemplateDeserializer<EnumeratorTemplateElement>
    {
        public override EnumeratorTemplateElement Deserialize(TemplateTokenizer tokenizer, AbstractTemplateElement root)
        {
            var result = new EnumeratorTemplateElement(root);

            tokenizer.AdvanceUntilChar(' ');
            tokenizer.AdvanceWhileChar(' ');

            switch (tokenizer.CurrentChar)
            {
                case '{':
                    result.EnumerationCondition = new VariableConditionPart {VariableName = tokenizer.AdvanceUntilChar('>').InfoBetween("{", "}") };
                    tokenizer.Advance();
                    break;
                case '[':
                    result.EnumerationCondition = ConditionDeserializer.Deserialize(tokenizer.AdvanceUntilChar(']').InfoAfter("[", int.MaxValue), new Dictionary<string, AbstractConditionPart>());
                    tokenizer.AdvanceUntilChar('>');
                    tokenizer.Advance();
                    break;
            }
            result.Elements = FindElements(result, tokenizer, "/FOREACH").ToArray();
            tokenizer.AdvanceUntilChar('>');
            return result;
        }
    }
}
