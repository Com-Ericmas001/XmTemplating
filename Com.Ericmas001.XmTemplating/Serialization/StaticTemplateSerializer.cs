using System.Collections.Generic;
using System.IO;
using System.Linq;
using Com.Ericmas001.XmTemplating.Serialization.Util;

namespace Com.Ericmas001.XmTemplating.Serialization
{
    public class StaticTemplateSerializer : AbstractTemplateSerializer<StaticTemplateElement>
    {
        public StaticTemplateSerializer(StaticTemplateElement element, IDictionary<string, string> variables, IDictionary<string, IEnumerable<string>> arrays, TemplateSerializationParms parms) : base(element, variables, arrays, parms)
        {
        }

        public override void Serialize(TextWriter tw)
        {
            tw.Write(Variables.Keys.Aggregate(Element.Content, (current, key) => current.Replace("{" + key + "}", Variables[key])));
        }
    }
}
