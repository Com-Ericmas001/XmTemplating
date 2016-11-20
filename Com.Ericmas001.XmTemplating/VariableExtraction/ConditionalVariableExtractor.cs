using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.VariableExtraction.Util;

namespace Com.Ericmas001.XmTemplating.VariableExtraction
{
    public class ConditionalVariableExtractor : AbstractVariableExtractor<ConditionalTemplateElement>
    {
        public override void ExtractVariables(IDictionary<string, ExtractedVariable> variables)
        {
            var vPart = Element.Condition as VariableConditionPart;
            if (vPart != null)
            {
                var xV = new ExtractedVariable(vPart.VariableName);
                xV.Values.Add(true.ToString());
                variables.Add(xV.Name, xV);
            }

            var opPart = Element.Condition as OperationConditionPart;
            if (opPart != null)
                ExtractVars(opPart, variables);

            foreach (var elem in Element.ConditionTrueElements)
                VariableExtractionFactory.ExtractVariables(elem, variables, Parms);

            if(Element.ConditionFalseElements != null)
                foreach (var elem in Element.ConditionFalseElements)
                    VariableExtractionFactory.ExtractVariables(elem, variables, Parms);
        }

        private void ExtractVars(OperationConditionPart opPart, IDictionary<string, ExtractedVariable> variables)
        {
            var opPartLeft = opPart.LeftSide as OperationConditionPart;
            var opPartRight = opPart.RightSide as OperationConditionPart;

            if (opPartLeft != null)
                ExtractVars(opPartLeft, variables);

            if (opPartRight != null)
                ExtractVars(opPartRight, variables);

            var opPartLeftV = opPart.LeftSide as VariableConditionPart;
            var opPartRightV = opPart.RightSide as VariableConditionPart;

            if (opPartLeftV != null && opPartRightV != null)
            {
                NoteVar(variables, opPartLeftV.VariableName, "{" + opPartRightV.VariableName + "}");
                NoteVar(variables, opPartRightV.VariableName, "{" + opPartLeftV.VariableName + "}");
            }
            else if (opPartLeftV != null)
                NoteVars(opPartLeftV, opPart.RightSide, variables);
            else if (opPartRightV != null)
                NoteVars(opPartRightV, opPart.LeftSide, variables);
        }
    }
}
