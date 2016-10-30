using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Com.Ericmas001.XmTemplating.Serialization.Util;

namespace Com.Ericmas001.XmTemplating.Serialization
{
    public class DefineTemplateSerializer : AbstractTemplateSerializer<DefineTemplateElement>
    {
        public DefineTemplateSerializer(DefineTemplateElement element, IDictionary<string, string> variables, IDictionary<string, IEnumerable<string>> arrays, TemplateSerializationParms parms) : base(element, variables, arrays, parms)
        {
        }

        public override void Serialize(TextWriter tw)
        {
            var sw = new StringWriter();
            foreach (var elem in Element.Elements)
                TemplateSerializationFactory.Serialize(sw, elem, Variables, Arrays, Parms);
            string result = sw.ToString();
            string[] lines = result.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(CleanLine).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            if(Element.IsArray)
                Arrays[Element.Variable.VariableName] = lines;
            else
                Variables[Element.Variable.VariableName] = string.Join(Environment.NewLine, lines);
        }

        private string CleanLine(string arg)
        {
            arg = arg.TrimEnd();
            if (arg.Length > 80)
                return arg.Remove(80);
            return arg;
        }
    }
}
