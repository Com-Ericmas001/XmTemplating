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

            var serializer = new XmTemplateSerializer();
            serializer.Initialize(element, variables, arrays, parms ?? new TemplateSerializationParms());
            serializer.Serialize(sw);

            string result = sw.ToString();
            string[] lines = result.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            return string.Join(Environment.NewLine, lines.Select(CleanLine).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray());
        }

        private static string CleanLine(string arg)
        {
            arg = arg.TrimEnd();
            if (arg.Length > 80)
                return arg.Remove(80);
            return arg;
        }
        public override void Serialize(TextWriter tw)
        {
            foreach (var elem in Element.Elements)
                TemplateSerializationFactory.Serialize(tw, elem, Variables, Arrays, Parms);
        }
    }
}
