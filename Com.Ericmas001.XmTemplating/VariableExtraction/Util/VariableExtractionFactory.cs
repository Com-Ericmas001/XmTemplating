using System;
using System.Collections.Generic;

namespace Com.Ericmas001.XmTemplating.VariableExtraction.Util
{
    public static class VariableExtractionFactory
    {
        public static void ExtractVariables(AbstractTemplateElement element, IDictionary<string, ExtractedVariable> variables, VariableExtractionParms parms)
        {
            if (element is StaticTemplateElement)
                new StaticVariableExtractor((StaticTemplateElement) element, parms).ExtractVariables(variables);

            else if (element is ConditionalTemplateElement)
                new ConditionalVariableExtractor((ConditionalTemplateElement)element, parms).ExtractVariables(variables);

            else if (element is EnumeratorTemplateElement)
                new EnumeratorVariableExtractor((EnumeratorTemplateElement)element, parms).ExtractVariables(variables);

            else if (element is RangeTemplateElement)
                new RangeVariableExtractor((RangeTemplateElement)element, parms).ExtractVariables(variables);

            else if (element is EvaluateTemplateElement)
                new EvaluateVariableExtractor((EvaluateTemplateElement)element, parms).ExtractVariables(variables);

            else if (element is DefineTemplateElement)
                new DefineVariableExtractor((DefineTemplateElement)element, parms).ExtractVariables(variables);

            else
                throw new ArgumentOutOfRangeException(nameof(element), $"Variable Extractor not found for element of type {element.GetType()}");
        }
    }
}
