using Com.Ericmas001.XmTemplating.Conditions.Util;

namespace Com.Ericmas001.XmTemplating.Conditions
{
    public class OperationConditionPart : AbstractConditionPart
    {
        public AbstractConditionPart LeftSide { get; set; }
        public AbstractConditionPart RightSide { get; set; }
        public ConditionPartOperatorEnum Operator { get; set; }

        public override string ToString()
        {
            return "(" + LeftSide + " [" + Operator + "] " + RightSide + ")";
        }
    }
}
