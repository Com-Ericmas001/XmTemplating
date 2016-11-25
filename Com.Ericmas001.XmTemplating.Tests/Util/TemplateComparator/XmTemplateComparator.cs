using System.Linq;
using NUnit.Framework;

namespace Com.Ericmas001.XmTemplating.Tests.Util.TemplateComparator
{
    public class XmTemplateComparator : AbstractTemplateComparator
    {
        protected override void Compare(AbstractTemplateElement left, AbstractTemplateElement right)
        {
            var leftElem = (XmTemplateElement)left;
            var rightElem = (XmTemplateElement)right;

            Assert.AreEqual(leftElem.Elements.Count(), rightElem.Elements.Count());

            var elemsL = leftElem.Elements.ToArray();
            var elemsR = rightElem.Elements.ToArray();

            for (int i = 0; i < elemsL.Length; ++i)
                CompareTemplateElements(elemsL[i],elemsR[i]);
        }
    }
}
