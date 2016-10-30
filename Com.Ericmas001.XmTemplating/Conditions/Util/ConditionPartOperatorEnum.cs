using Com.Ericmas001.Common.Attributes;

namespace Com.Ericmas001.XmTemplating.Conditions.Util
{
    public enum ConditionPartOperatorEnum
    {
        [SupportedOperator]
        [Priority(-1)]
        Unknown,

        [SupportedOperator(" OR ", "||")]
        [Priority(10)]
        [Sequential]
        Or,

        [SupportedOperator(" AND ", "&&")]
        [Priority(11)]
        [Sequential]
        And,

        [SupportedOperator("<", " LT ")]
        [Priority(20)]
        LowerThan,

        [SupportedOperator("<=", " LE ")]
        [Priority(20)]
        LowerOrEqual,

        [SupportedOperator("==", " EQ ", "=")]
        [Priority(20)]
        Equals,

        [SupportedOperator(">=", " GE ")]
        [Priority(20)]
        GreaterOrEqual,

        [SupportedOperator(">", " GT ")]
        [Priority(20)]
        GreaterThan,

        [SupportedOperator("<>", "!=", " NE ", " NQ ")]
        [Priority(20)]
        Different,

        [SupportedOperator(" IN ")]
        [Priority(110)]
        In,

        [SupportedOperator(" FROM ")]
        [Priority(120)]
        Range,

        [SupportedOperator(" TO ")]
        [Priority(130)]
        To,

        [SupportedOperator(" UNTIL ")]
        [Priority(130)]
        Until,

        [SupportedOperator("*")]
        [Priority(300)]
        Multiply,

        [SupportedOperator("/")]
        [Priority(300)]
        Divide,

        [SupportedOperator("+")]
        [Priority(310)]
        Add,

        [SupportedOperator("-")]
        [Priority(310)]
        Subtract
    }
}
