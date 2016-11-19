using System.Collections.Generic;
using System.IO;
using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Conditions.Util;
using Com.Ericmas001.XmTemplating.Serialization.Util;

namespace Com.Ericmas001.XmTemplating.Serialization
{
    [TemplateElement(typeof(EvaluateTemplateElement))]
    public class EvaluateTemplateSerializer : AbstractTemplateSerializer<EvaluateTemplateElement>
    {
        public override void Serialize(TextWriter tw)
        {
            tw.Write(ConditionSerializer.Serialize(Element.Expression, new Dictionary<string, string>(Variables), new Dictionary<string, IEnumerable<string>>(Arrays)));
        }
    }
}
