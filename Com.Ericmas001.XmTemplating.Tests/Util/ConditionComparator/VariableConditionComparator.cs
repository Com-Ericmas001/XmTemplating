using Com.Ericmas001.XmTemplating.Conditions;
using NUnit.Framework;

namespace Com.Ericmas001.XmTemplating.Tests.Util.ConditionComparator
{
    public class VariableConditionComparator : AbstractConditionComparator
    {
        protected override void Compare(AbstractConditionPart left, AbstractConditionPart right)
        {
            var leftElem = (VariableConditionPart)left;
            var rightElem = (VariableConditionPart)right;

            Assert.AreEqual(leftElem.VariableName, rightElem.VariableName);
        }
    }
}
