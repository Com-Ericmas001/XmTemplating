using System;
using NUnit.Framework;

namespace Com.Ericmas001.XmTemplating.Tests.Util.TemplateComparator
{
    public abstract class AbstractTemplateComparator
    {
        protected abstract void Compare(AbstractTemplateElement left, AbstractTemplateElement right);

        public static void CompareTemplateElements(AbstractTemplateElement left, AbstractTemplateElement right)
        {
            Assert.IsNotNull(left);
            Assert.IsNotNull(right);
            Assert.IsTrue(right.GetType().IsInstanceOfType(left));

            if (left is XmTemplateElement)
                new XmTemplateComparator().Compare(left, right);

            else if (left is StaticTemplateElement)
                new StaticTemplateComparator().Compare(left, right);

            else if (left is DefineTemplateElement)
                new DefineTemplateComparator().Compare(left, right);

            else if (left is ConditionalTemplateElement)
                new ConditionnalTemplateComparator().Compare(left, right);

            else if (left is EnumeratorTemplateElement)
                new EnumeratorTemplateComparator().Compare(left, right);

            else if (left is EvaluateTemplateElement)
                new EvaluateTemplateComparator().Compare(left, right);

            else if (left is RangeTemplateElement)
                new RangeTemplateComparator().Compare(left, right);

            else
                throw new NotImplementedException("Unable to compare template, template element not supported " + right.GetType());
        }
    }
}
