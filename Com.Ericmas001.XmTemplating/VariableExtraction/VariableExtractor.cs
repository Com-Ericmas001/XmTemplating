using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Com.Ericmas001.XmTemplating.VariableExtraction.Util;

namespace Com.Ericmas001.XmTemplating.VariableExtraction
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class VariableExtractor : AbstractVariableExtractor<XmTemplateElement>
    {
        private VariableExtractor()
        {
        }

        public static IDictionary<string, ExtractedVariable> ExtractVariables(AbstractTemplateElement element, VariableExtractionParms parms = null)
        {
            var variables = new Dictionary<string, ExtractedVariable>();

            var extractor = new VariableExtractor();
            extractor.Initialize(element, parms ?? new VariableExtractionParms());
            extractor.ExtractVariables(variables);

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
