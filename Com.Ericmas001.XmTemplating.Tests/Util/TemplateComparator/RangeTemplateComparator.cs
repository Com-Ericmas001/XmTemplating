using System.Linq;
using Com.Ericmas001.XmTemplating.Tests.Util.ConditionComparator;
using NUnit.Framework;

namespace Com.Ericmas001.XmTemplating.Tests.Util.TemplateComparator
{
    public class RangeTemplateComparator : AbstractTemplateComparator
    {
        protected override void Compare(AbstractTemplateElement left, AbstractTemplateElement right)
        {
            var leftElem = (RangeTemplateElement)left;
            var rightElem = (RangeTemplateElement)right;

            AbstractConditionComparator.CompareConditionParts(leftElem.Minimum, rightElem.Minimum);
            AbstractConditionComparator.CompareConditionParts(leftElem.Maximum, rightElem.Maximum);
            Assert.AreEqual(leftElem.InludeMaximum, rightElem.InludeMaximum);
            Assert.AreEqual(leftElem.Elements.Count(), rightElem.Elements.Count());

            var elemsL = leftElem.Elements.ToArray();
            var elemsR = rightElem.Elements.ToArray();

            for (int i = 0; i < elemsL.Length; ++i)
                CompareTemplateElements(elemsL[i], elemsR[i]);
        }
    }
}
