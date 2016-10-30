using System;
using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.Common;
using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.Conditions.Util;
using Com.Ericmas001.XmTemplating.Deserialization.Util;
using Com.Ericmas001.XmTemplating.Enums;

namespace Com.Ericmas001.XmTemplating.Deserialization
{
    [TemplateCommand(TemplateCommandEnum.For)]
    public class RangeTemplateDeserializer : AbstractTemplateDeserializer<RangeTemplateElement>
    {
        public override RangeTemplateElement Deserialize(TemplateTokenizer tokenizer, AbstractTemplateElement root)
        {
            var result = new RangeTemplateElement(root);

            tokenizer.AdvanceUntilChar(' ');
            tokenizer.AdvanceWhileChar(' ');

            if (tokenizer.CurrentChar == '[')
            {
                var condition = ConditionDeserializer.Deserialize(tokenizer.AdvanceUntilChar(']').InfoAfter("[", int.MaxValue), new Dictionary<string, AbstractConditionPart>());
                var opCond = condition as OperationConditionPart;
                if(!(opCond?.LeftSide is VariableConditionPart) || opCond.Operator != ConditionPartOperatorEnum.Range || !(opCond.RightSide is OperationConditionPart))
                    throw new ArgumentException("Invalid FOR condition");

                result.Variable = (VariableConditionPart) opCond.LeftSide;
                var cond = (OperationConditionPart)opCond.RightSide;

                if (cond.Operator != ConditionPartOperatorEnum.To && cond.Operator != ConditionPartOperatorEnum.Until)
                    throw new ArgumentException("Invalid FOR condition");

                result.InludeMaximum = cond.Operator == ConditionPartOperatorEnum.To;
                result.Minimum = cond.LeftSide;
                result.Maximum = cond.RightSide;

                tokenizer.AdvanceUntilChar('>');
                tokenizer.Advance();
            }
            else
                throw new ArgumentException("FOR must have a condition in []");

            result.Elements = FindElements(result, tokenizer, "/FOR").ToArray();
            tokenizer.AdvanceUntilChar('>');
            return result;
        }
    }
}
