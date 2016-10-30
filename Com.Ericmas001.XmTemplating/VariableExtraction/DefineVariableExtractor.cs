using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.VariableExtraction.Util;

namespace Com.Ericmas001.XmTemplating.VariableExtraction
{
    public class DefineVariableExtractor : AbstractVariableExtractor<DefineTemplateElement>
    {
        public DefineVariableExtractor(DefineTemplateElement element, VariableExtractionParms parms) : base(element, parms)
        {
        }

        public override void ExtractVariables(IDictionary<string, ExtractedVariable> variables)
        {
            var v = GetVar(variables, Element.Variable.VariableName);
            v.IsLocal = true;

            foreach (var elem in Element.Elements)
                VariableExtractionFactory.ExtractVariables(elem, variables, Parms);
        }
    }
}
