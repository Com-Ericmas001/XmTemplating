using System;
using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.Common;

namespace Com.Ericmas001.XmTemplating.Conditions.Util
{
    public static class ConditionDeserializer
    {
        public static AbstractConditionPart Deserialize(string condition, IDictionary<string, AbstractConditionPart> dicConditionPart)
        {
            condition = condition.Trim();
            condition = ManageDelmitter(condition, dicConditionPart, "\"", "\"", x => new LiteralConditionPart { Value = x });              // Literals
            condition = ManageDelmitter(condition, dicConditionPart, "{", "}", x => new VariableConditionPart { VariableName = x });        // Variables
            condition = ManageDelmitter(condition, dicConditionPart, "(", ")", x => Deserialize(x, dicConditionPart));                      // Parantheses

            var dicOps = EnumUtil.AllValues<ConditionPartOperatorEnum>().Where(x => x.Priority() > 0).GroupBy(x => x.Priority()).ToDictionary(x => x.Key, x => x.ToArray());

            foreach (var grpOper in dicOps.Keys.OrderBy(x => x))
            {
                var operators = dicOps[grpOper];
                var allOps = operators.SelectMany(x => x.GetAttribute<SupportedOperatorAttribute>().Operators.Select(o => new KeyValuePair<string, ConditionPartOperatorEnum>(o, x))).OrderBy(x => 0 - x.Key.Length);
                foreach (var o in allOps)
                {
                    var isSequential = o.Value.GetAttribute<SequentialAttribute>() != null;
                    var curOps = o.Value.GetAttribute<SupportedOperatorAttribute>().Operators.OrderBy(x => 0 - x.Length).ToArray();
                    string op;
                    while ((op = FindFirstOper(condition, isSequential ? curOps : new []{o.Key})) != null)
                        condition = DeserializeGroupOperator(condition, dicConditionPart, op, allOps.Select(x => x.Key).ToArray(), o.Value);
                }
            }

            condition = condition.Trim();

            if (condition.Contains(","))
            {
                var conditions = condition.Split(',').Select(x => x.Trim()).ToArray();
                return new GroupedConditionPart { Values = conditions.Select(x => dicConditionPart[x.InfoBetween("[", "]")]) };
            }
            return dicConditionPart[condition.InfoBetween("[", "]")];
        }

        private static string ManageDelmitter(string condition, IDictionary<string, AbstractConditionPart> dicConditionPart, string startDelimitter, string endDelimitter, Func<string,AbstractConditionPart> extractFunc )
        {
            while (condition.Contains(startDelimitter))
            {
                string subCondition = condition.InfoBetween(startDelimitter, endDelimitter, condition.LastIndexOf(startDelimitter, condition.LastIndexOf(endDelimitter, StringComparison.Ordinal) - 1, StringComparison.Ordinal));
                string g = NumberGiver.NewNumber();
                dicConditionPart.Add(g, extractFunc(subCondition));
                condition = condition.Replace(startDelimitter + subCondition + endDelimitter, "[" + g + "]");
            }
            return condition;
        }

        private static string FindFirstOper(string condition, string[] opOr)
        {
            return opOr.ToDictionary(x => x, x => condition.ToUpper().IndexOf(x, StringComparison.Ordinal)).Where(x => x.Value >= 0).OrderBy(x => x.Value).Select(x => x.Key).FirstOrDefault();
        }

        private static string DeserializeGroupOperator(string condition, IDictionary<string, AbstractConditionPart> dicConditionPart, string op, string[] equivalentOperators, ConditionPartOperatorEnum oper)
        {
            int iOp = condition.ToUpper().IndexOf(op, StringComparison.Ordinal);
            int iAfterOp = iOp + op.Length;
            var left = Deserialize(condition.Remove(iOp), dicConditionPart);
            var iNexts = equivalentOperators.Select(x => condition.ToUpper().IndexOf(x, iAfterOp, StringComparison.Ordinal)).Where(i => i >= 0).ToArray();
            var iNext = iNexts.Any() ? iNexts.Min() - 1 : condition.Length;
            var right = Deserialize(condition.Substring(iAfterOp, iNext - iAfterOp), dicConditionPart);
            string g = NumberGiver.NewNumber();
            dicConditionPart.Add(g, new OperationConditionPart { LeftSide = left, Operator = oper, RightSide = right });
            return "[" + g + "]" + (iNext < condition.Length ? condition.Substring(iNext + 1) : "");
        }
    }
}
