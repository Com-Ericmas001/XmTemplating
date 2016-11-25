using System.Linq;
using Com.Ericmas001.XmTemplating.Tests.Util.ConditionComparator;
using NUnit.Framework;

namespace Com.Ericmas001.XmTemplating.Tests.Util.TemplateComparator
{
    public class ConditionnalTemplateComparator : AbstractTemplateComparator
    {
        protected override void Compare(AbstractTemplateElement left, AbstractTemplateElement right)
        {
            var leftElem = (ConditionalTemplateElement)left;
            var rightElem = (ConditionalTemplateElement)right;

            AbstractConditionComparator.CompareTemplateElements(leftElem.Condition, rightElem.Condition);
            Assert.AreEqual(leftElem.ConditionTrueElements.Count(), rightElem.ConditionTrueElements.Count());

            var elems1L = leftElem.ConditionTrueElements.ToArray();
            var elems1R = rightElem.ConditionTrueElements.ToArray();

            for (int i = 0; i < elems1L.Length; ++i)
                CompareTemplateElements(elems1L[i], elems1R[i]);

            Assert.AreEqual(leftElem.ConditionFalseElements?.Count(), rightElem.ConditionFalseElements?.Count());
            if (leftElem.ConditionFalseElements != null)
            {
                var elems2L = leftElem.ConditionFalseElements.ToArray();
                var elems2R = rightElem.ConditionFalseElements.ToArray();

                for (int i = 0; i < elems2L.Length; ++i)
                    CompareTemplateElements(elems2L[i], elems2R[i]);
            }
        }
    }
}
