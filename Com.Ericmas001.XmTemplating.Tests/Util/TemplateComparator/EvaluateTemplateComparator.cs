using System.Linq;
using Com.Ericmas001.XmTemplating.Tests.Util.ConditionComparator;
using NUnit.Framework;

namespace Com.Ericmas001.XmTemplating.Tests.Util.TemplateComparator
{
    public class EvaluateTemplateComparator : AbstractTemplateComparator
    {
        protected override void Compare(AbstractTemplateElement left, AbstractTemplateElement right)
        {
            var leftElem = (EvaluateTemplateElement)left;
            var rightElem = (EvaluateTemplateElement)right;

            AbstractConditionComparator.CompareConditionParts(leftElem.Expression, rightElem.Expression);
        }
    }
}
