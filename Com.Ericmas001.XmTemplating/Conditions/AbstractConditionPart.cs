using System;
using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.XmTemplating.Conditions.Util;
using Com.Ericmas001.XmTemplating.Enums;

namespace Com.Ericmas001.XmTemplating.Conditions
{
    public abstract class AbstractConditionPart
    {


        public bool Evaluate(IDictionary<string, string> variables, IDictionary<string, IEnumerable<string>> arrays)
        {
            var op = this as OperationConditionPart;
            if (op == null)
                return true;

            switch (op.Operator)
            {
                case ConditionPartOperatorEnum.And:
                    return ConditionSerializer.Serialize(op.LeftSide, new Dictionary<string, string>(variables), arrays) == true.ToString() && ConditionSerializer.Serialize(op.RightSide, new Dictionary<string, string>(variables), arrays) == true.ToString();
                case ConditionPartOperatorEnum.Or:
                    return ConditionSerializer.Serialize(op.LeftSide, new Dictionary<string, string>(variables), arrays) == true.ToString() || ConditionSerializer.Serialize(op.RightSide, new Dictionary<string, string>(variables), arrays) == true.ToString();
                case ConditionPartOperatorEnum.Equals:
                    return CompareLeftAndRight(ConditionSerializer.Serialize(op.LeftSide, variables, arrays), ConditionSerializer.Serialize(op.RightSide, variables, arrays)) == 0;
                case ConditionPartOperatorEnum.Different:
                    return CompareLeftAndRight(ConditionSerializer.Serialize(op.LeftSide, variables, arrays), ConditionSerializer.Serialize(op.RightSide, variables, arrays)) != 0;
                case ConditionPartOperatorEnum.LowerThan:
                    return CompareLeftAndRight(ConditionSerializer.Serialize(op.LeftSide, variables, arrays), ConditionSerializer.Serialize(op.RightSide, variables, arrays)) < 0;
                case ConditionPartOperatorEnum.LowerOrEqual:
                    return CompareLeftAndRight(ConditionSerializer.Serialize(op.LeftSide, variables, arrays), ConditionSerializer.Serialize(op.RightSide, variables, arrays)) <= 0;
                case ConditionPartOperatorEnum.GreaterOrEqual:
                    return CompareLeftAndRight(ConditionSerializer.Serialize(op.LeftSide, variables, arrays), ConditionSerializer.Serialize(op.RightSide, variables, arrays)) >= 0;
                case ConditionPartOperatorEnum.GreaterThan:
                    return CompareLeftAndRight(ConditionSerializer.Serialize(op.LeftSide, variables, arrays), ConditionSerializer.Serialize(op.RightSide, variables, arrays)) > 0;
                case ConditionPartOperatorEnum.In:
                    var left = ConditionSerializer.Serialize(op.LeftSide, variables, arrays);
                    IEnumerable<string> values = null;
                    if (left == null)
                        throw new ArgumentException("the IN is impossible to resolve");
                    if (op.RightSide is GroupedConditionPart)
                        values = ((GroupedConditionPart)op.RightSide).Values.Select(x => ConditionSerializer.Serialize(x, variables, arrays));
                    else if (op.RightSide is VariableConditionPart && arrays.ContainsKey(((VariableConditionPart) op.RightSide).VariableName))
                        values = arrays[((VariableConditionPart) op.RightSide).VariableName];
                    else
                        throw new ArgumentException("the IN is impossible to resolve");
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
