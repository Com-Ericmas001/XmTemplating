using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.VariableExtraction.Util;

namespace Com.Ericmas001.XmTemplating.VariableExtraction
{
    public class EnumeratorVariableExtractor : AbstractVariableExtractor<EnumeratorTemplateElement>
    {
        public override void ExtractVariables(IDictionary<string, ExtractedVariable> variables)
        {
            string variable;
            var opCond = Element.EnumerationCondition as OperationConditionPart;
            if (opCond != null)
            {
                variable = ((VariableConditionPart) opCond.LeftSide).VariableName;
                //NoteLocalVar(variables, variable);
                foreach (var val in ((GroupedConditionPart)opCond.RightSide).Values)
                    NoteVars((VariableConditionPart)opCond.LeftSide, val, variables);
            }
            else
            {
                variable = ((VariableConditionPart) Element.EnumerationCondition).VariableName;
                NoteArrayVar(variables, variable);
            }

            foreach (var elem in Element.Elements)
                VariableExtractionFactory.ExtractVariables(elem, variables, Parms);


            if (opCond != null)
            {
                var v = GetVar(variables, variable);
                variables.Remove(variable);
                foreach (var extractedVariable in variables.Values.ToArray())
                {
                    extractedVariable.ConvertVarNameToLink(v);
                    v.ConvertVarNameToLink(extractedVariable);
                }
            }
        }
    }
}
