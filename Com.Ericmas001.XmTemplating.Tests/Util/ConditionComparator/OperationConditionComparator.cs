using Com.Ericmas001.XmTemplating.Conditions;
using NUnit.Framework;

namespace Com.Ericmas001.XmTemplating.Tests.Util.ConditionComparator
{
    public class OperationConditionComparator : AbstractConditionComparator
    {
        protected override void Compare(AbstractConditionPart left, AbstractConditionPart right)
        {
            var leftElem = (OperationConditionPart)left;
            var rightElem = (OperationConditionPart)right;

            Assert.AreEqual(leftElem.Operator, rightElem.Operator);
            CompareConditionParts(leftElem.LeftSide, rightElem.LeftSide);
            CompareConditionParts(leftElem.RightSide, rightElem.RightSide);
        }
    }
}
