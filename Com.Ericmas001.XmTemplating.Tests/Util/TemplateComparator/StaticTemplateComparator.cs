using System.Linq;
using NUnit.Framework;

namespace Com.Ericmas001.XmTemplating.Tests.Util.TemplateComparator
{
    public class StaticTemplateComparator : AbstractTemplateComparator
    {
        protected override void Compare(AbstractTemplateElement left, AbstractTemplateElement right)
        {
            var leftElem = (StaticTemplateElement)left;
            var rightElem = (StaticTemplateElement)right;

            Assert.AreEqual(leftElem.Content, rightElem.Content);
        }
    }
}
