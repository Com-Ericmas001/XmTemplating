using Com.Ericmas001.XmTemplating.Conditions;
using NUnit.Framework;

namespace Com.Ericmas001.XmTemplating.Tests.Util.ConditionComparator
{
    public class LiteralConditionComparator : AbstractConditionComparator
    {
        protected override void Compare(AbstractConditionPart left, AbstractConditionPart right)
        {
            var leftElem = (LiteralConditionPart)left;
            var rightElem = (LiteralConditionPart)right;

            Assert.AreEqual(leftElem.Value, rightElem.Value);
        }
    }
}
