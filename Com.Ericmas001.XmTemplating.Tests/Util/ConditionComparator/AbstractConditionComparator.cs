using System;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.Tests.Util.TemplateComparator;
using NUnit.Framework;

namespace Com.Ericmas001.XmTemplating.Tests.Util.ConditionComparator
{
    public abstract class AbstractConditionComparator
    {
        protected abstract void Compare(AbstractConditionPart left, AbstractConditionPart right);

        public static void CompareConditionParts(AbstractConditionPart left, AbstractConditionPart right)
        {
            Assert.IsNotNull(left);
            Assert.IsNotNull(right);
            Assert.IsTrue(right.GetType().IsInstanceOfType(left));

            if (left is LiteralConditionPart)
                new LiteralConditionComparator().Compare(left, right);
            else if (left is OperationConditionPart)
                new OperationConditionComparator().Compare(left, right);
            else if (left is VariableConditionPart)
                new VariableConditionComparator().Compare(left, right);
            else if (left is GroupedConditionPart)
                new GroupedConditionComparator().Compare(left, right);
            else
                throw new NotImplementedException("Unable to compare condition, condition part not supported " + right.GetType());
        }
    }
}
