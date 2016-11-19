using System.Collections.Generic;
using System.IO;
using System.Linq;
using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Serialization.Util;

namespace Com.Ericmas001.XmTemplating.Serialization
{
    public class StaticTemplateSerializer : AbstractTemplateSerializer<StaticTemplateElement>
    {
        public override void Serialize(TextWriter tw)
        {
            tw.Write(Variables.Keys.Aggregate(Element.Content, (current, key) => current.Replace("{" + key + "}", Variables[key])));
        }
    }
}
