using System.Linq;
using NUnit.Framework;

namespace Com.Ericmas001.XmTemplating.Tests.Util.TemplateComparator
{
    public class DefineTemplateComparator : AbstractTemplateComparator
    {
        protected override void Compare(AbstractTemplateElement left, AbstractTemplateElement right)
        {
            var leftElem = (DefineTemplateElement)left;
            var rightElem = (DefineTemplateElement)right;

            Assert.AreEqual(leftElem.IsArray, rightElem.IsArray);
            Assert.AreEqual(leftElem.Variable.VariableName, rightElem.Variable.VariableName);
            Assert.AreEqual(leftElem.Elements.Count(), rightElem.Elements.Count());

            var elemsL = leftElem.Elements.ToArray();
            var elemsR = rightElem.Elements.ToArray();

            for (int i = 0; i < elemsL.Length; ++i)
                CompareTemplateElements(elemsL[i], elemsR[i]);
        }
    }
}
