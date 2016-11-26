using System.Linq;
using Com.Ericmas001.XmTemplating.Conditions;
using NUnit.Framework;

namespace Com.Ericmas001.XmTemplating.Tests.Util.ConditionComparator
{
    public class GroupedConditionComparator : AbstractConditionComparator
    {
        protected override void Compare(AbstractConditionPart left, AbstractConditionPart right)
        {
            var leftElem = (GroupedConditionPart)left;
            var rightElem = (GroupedConditionPart)right;

            Assert.AreEqual(leftElem.Values.Count(), rightElem.Values.Count());
            Assert.IsTrue(leftElem.Values.Except(rightElem.Values).Any());
        }
    }
}
