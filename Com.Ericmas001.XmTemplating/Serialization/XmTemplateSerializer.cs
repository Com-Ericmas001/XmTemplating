using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Com.Ericmas001.XmTemplating.Serialization.Util;

namespace Com.Ericmas001.XmTemplating.Serialization
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class XmTemplateSerializer : AbstractTemplateSerializer<XmTemplateElement>
    {
        private XmTemplateSerializer()
        {
        }

        public static string Serialize(XmTemplateElement element, IDictionary<string, string> variables, IDictionary<string, IEnumerable<string>> arrays, TemplateSerializationParms parms = null)
        {
            var sw = new StringWriter();
            var serParms = parms ?? new TemplateSerializationParms();
            var serializer = new XmTemplateSerializer();
            serializer.Initialize(element, variables, arrays, parms ?? new TemplateSerializationParms());
            serializer.Serialize(sw);

            string result = sw.ToString();
            string[] lines = result.Replace(Environment.NewLine, "\n").Split('\n');

            //First trim pass
            if (serParms.TrimEndOfLines)
                lines = lines.Select(x => x.TrimEnd()).ToArray();

            //Limiting lines length
            if (serParms.MaxLineLength > 0)
                lines = lines.Select(x => x.Length > 80 ? x.Remove(80) : x).ToArray();

            //Second trim pass
            if (serParms.TrimEndOfLines)
                lines = lines.Select(x => x.TrimEnd()).ToArray();

            //Removing empty lines
            if (serParms.RemoveEmptyLines)
                lines = lines.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            
            return string.Join(Environment.NewLine, lines).Replace("<:BR:>", "");
        }

        public override void Serialize(TextWriter tw)
        {
            foreach (var elem in Element.Elements)
                TemplateSerializationFactory.Serialize(tw, elem, Variables, Arrays, Parms);
        }
    }
}
