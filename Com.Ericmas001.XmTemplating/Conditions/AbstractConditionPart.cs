using System;
using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.XmTemplating.Conditions.Util;
using Com.Ericmas001.XmTemplating.Enums;

namespace Com.Ericmas001.XmTemplating.Conditions
{
    public abstract class AbstractConditionPart
    {


        public bool Evaluate(IDictionary<string, string> variables)
        {
            var op = this as OperationConditionPart;
            if (op == null)
                return true;

            switch (op.Operator)
            {
                case ConditionPartOperatorEnum.And:
                    return op.LeftSide.Evaluate(variables) && op.RightSide.Evaluate(variables);
                case ConditionPartOperatorEnum.Or:
                    return op.LeftSide.Evaluate(variables) || op.RightSide.Evaluate(variables);
                case ConditionPartOperatorEnum.Equals:
                    return CompareLeftAndRight(ConditionSerializer.Serialize(op.LeftSide, variables), ConditionSerializer.Serialize(op.RightSide, variables)) == 0;
                case ConditionPartOperatorEnum.Different:
                    return CompareLeftAndRight(ConditionSerializer.Serialize(op.LeftSide, variables), ConditionSerializer.Serialize(op.RightSide, variables)) != 0;
                case ConditionPartOperatorEnum.LowerThan:
                    return CompareLeftAndRight(ConditionSerializer.Serialize(op.LeftSide, variables), ConditionSerializer.Serialize(op.RightSide, variables)) < 0;
                case ConditionPartOperatorEnum.LowerOrEqual:
                    return CompareLeftAndRight(ConditionSerializer.Serialize(op.LeftSide, variables), ConditionSerializer.Serialize(op.RightSide, variables)) <= 0;
                case ConditionPartOperatorEnum.GreaterOrEqual:
                    return CompareLeftAndRight(ConditionSerializer.Serialize(op.LeftSide, variables), ConditionSerializer.Serialize(op.RightSide, variables)) >= 0;
                case ConditionPartOperatorEnum.GreaterThan:
                    return CompareLeftAndRight(ConditionSerializer.Serialize(op.LeftSide, variables), ConditionSerializer.Serialize(op.RightSide, variables)) > 0;
                case ConditionPartOperatorEnum.In:
                    var left = ConditionSerializer.Serialize(op.LeftSide, variables);
                    if (left == null || !(op.RightSide is GroupedConditionPart))
                        throw new ArgumentException("the IN is impossible to resolve");
                    var values = ((GroupedConditionPart)op.RightSide).Values.Select(x => ConditionSerializer.Serialize(x, variables));
                    return values.Any(x => CompareLeftAndRight(left, x) == 0);
            }

            return false;
        }

        private int CompareLeftAndRight(string left, string right)
        {
            if (left == null)
                return -1;
            if (right == null)
                return 1;

            if (left.ToCharArray().All(char.IsDigit) && right.ToCharArray().All(char.IsDigit))
                return int.Parse(left).CompareTo(int.Parse(right));

            return string.Compare(left, right, StringComparison.Ordinal);
        }
    }

}
