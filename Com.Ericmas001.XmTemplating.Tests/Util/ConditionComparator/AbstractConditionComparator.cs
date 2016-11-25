using System;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.Tests.Util.TemplateComparator;
using NUnit.Framework;

namespace Com.Ericmas001.XmTemplating.Tests.Util.ConditionComparator
{
    public abstract class AbstractConditionComparator
    {
        protected abstract void Compare(AbstractConditionPart left, AbstractConditionPart right);

        public static void CompareTemplateElements(AbstractConditionPart left, AbstractConditionPart right)
        {
            Assert.IsNotNull(left);
            Assert.IsNotNull(right);
            Assert.IsTrue(right.GetType().IsInstanceOfType(left));
            throw new NotImplementedException("Unable to compare condition, condition part not supported");
        }
    }
}
