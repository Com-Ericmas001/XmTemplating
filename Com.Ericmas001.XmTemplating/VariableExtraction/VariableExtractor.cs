using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.XmTemplating.VariableExtraction.Util;

namespace Com.Ericmas001.XmTemplating.VariableExtraction
{
    public class VariableExtractor : AbstractVariableExtractor<XmTemplateElement>
    {
        public VariableExtractor(XmTemplateElement element, VariableExtractionParms parms = null) : base(element, parms ?? new VariableExtractionParms())
        {
        }

        public IDictionary<string, ExtractedVariable> ExtractVariables()
        {
            var variables = new Dictionary<string, ExtractedVariable>();
            ExtractVariables(variables);
            return variables.Where(x => !x.Value.IsLocal).ToDictionary(x => x.Key, x=> x.Value);
        }
        public override void ExtractVariables(IDictionary<string, ExtractedVariable> variables)
        {
            foreach (var elem in Element.Elements)
                VariableExtractionFactory.ExtractVariables(elem,variables, Parms);


            foreach (var v in variables.Values.ToArray())
                foreach (var extractedVariable in variables.Values.ToArray())
                {
                    extractedVariable.ConvertVarNameToLink(v);
                    v.ConvertVarNameToLink(extractedVariable);
                }

            foreach (var v in variables.Values.ToArray())
            {
                v.ExpandLinks();
                v.GuessType();
            }
        }
    }
}
