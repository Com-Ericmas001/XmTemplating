using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.Enums;

namespace Com.Ericmas001.XmTemplating.Conditions.Util
{
    public static class ConditionSerializer
    {
        public static string Serialize(AbstractConditionPart cond, IDictionary<string, string> variables, IDictionary<string, IEnumerable<string>> arrays)
        {
            var valOp = cond as LiteralConditionPart;
            if (valOp != null)
                return valOp.Value;

            var varOp = cond as VariableConditionPart;
            if (varOp != null)
            {
                if (!variables.ContainsKey(varOp.VariableName))
                    return null;
                return variables[varOp.VariableName];
            }


            var oOp = cond as OperationConditionPart;
            if (oOp != null)
            {
                switch (oOp.Operator)
                {
                    case ConditionPartOperatorEnum.Multiply:
                        return (int.Parse(Serialize(oOp.LeftSide, variables, arrays)) * int.Parse(Serialize(oOp.RightSide, variables, arrays))).ToString();
                    case ConditionPartOperatorEnum.Divide:
                        return (int.Parse(Serialize(oOp.LeftSide, variables, arrays)) / int.Parse(Serialize(oOp.RightSide, variables, arrays))).ToString();
                    case ConditionPartOperatorEnum.Add:
                        return (int.Parse(Serialize(oOp.LeftSide, variables, arrays)) + int.Parse(Serialize(oOp.RightSide, variables, arrays))).ToString();
                    case ConditionPartOperatorEnum.Subtract:
                        return (int.Parse(Serialize(oOp.LeftSide, variables, arrays)) - int.Parse(Serialize(oOp.RightSide, variables, arrays))).ToString();
                    default:
                        return oOp.Evaluate(variables, arrays).ToString();
                }
            }

            return null;
        }
    }
}
