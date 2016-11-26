using System.Linq;
using Com.Ericmas001.XmTemplating.Tests.Util.ConditionComparator;
using NUnit.Framework;

namespace Com.Ericmas001.XmTemplating.Tests.Util.TemplateComparator
{
    public class EnumeratorTemplateComparator : AbstractTemplateComparator
    {
        protected override void Compare(AbstractTemplateElement left, AbstractTemplateElement right)
        {
            var leftElem = (EnumeratorTemplateElement)left;
            var rightElem = (EnumeratorTemplateElement)right;

            AbstractConditionComparator.CompareConditionParts(leftElem.EnumerationCondition, rightElem.EnumerationCondition);
            Assert.AreEqual(leftElem.Elements.Count(), rightElem.Elements.Count());

            var elemsL = leftElem.Elements.ToArray();
            var elemsR = rightElem.Elements.ToArray();

            for (int i = 0; i < elemsL.Length; ++i)
                CompareTemplateElements(elemsL[i], elemsR[i]);
        }
    }
}
