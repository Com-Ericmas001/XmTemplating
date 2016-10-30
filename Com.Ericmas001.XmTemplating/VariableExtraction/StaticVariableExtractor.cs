using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.Common;
using Com.Ericmas001.XmTemplating.VariableExtraction.Util;

namespace Com.Ericmas001.XmTemplating.VariableExtraction
{
    public class StaticVariableExtractor : AbstractVariableExtractor<StaticTemplateElement>
    {
        public StaticVariableExtractor(StaticTemplateElement element, VariableExtractionParms parms) : base(element, parms)
        {
        }

        public override void ExtractVariables(IDictionary<string, ExtractedVariable> variables)
        {
            var content = variables.Keys.Aggregate(Element.Content, (current, key) => current.Replace("{" + key + "}", ""));
            while (content.Contains("{"))
            {
                var key = content.InfoBetween("{", "}");
                content = content.Replace("{" + key + "}", "");
                variables.Add(key,new ExtractedVariable(key));
            }
        }
    }
}
