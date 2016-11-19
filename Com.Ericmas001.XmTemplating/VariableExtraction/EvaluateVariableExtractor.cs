using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.VariableExtraction.Util;

namespace Com.Ericmas001.XmTemplating.VariableExtraction
{
    public class EvaluateVariableExtractor : AbstractVariableExtractor<EvaluateTemplateElement>
    {
        public override void ExtractVariables(IDictionary<string, ExtractedVariable> variables)
        {
            var opPart = Element.Expression as OperationConditionPart;
            if(opPart != null)
                ExtractVars(opPart, variables);
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
