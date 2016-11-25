using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.VariableExtraction.Util;

namespace Com.Ericmas001.XmTemplating.VariableExtraction
{
    public class RangeVariableExtractor : AbstractVariableExtractor<RangeTemplateElement>
    {
        public override void ExtractVariables(IDictionary<string, ExtractedVariable> variables)
        {
            var itVar = GetVar(variables, Element.Variable.VariableName);
            itVar.AddValue("0");

            ExtractVar(variables, Element.Minimum, itVar);
            var minL = Element.Minimum as LiteralConditionPart;
            if(minL != null)
                itVar.AddValue(minL.Value);

            ExtractVar(variables, Element.Maximum, itVar);
            var maxL = Element.Maximum as LiteralConditionPart;
            if (maxL != null)
                itVar.AddValue(maxL.Value);

            foreach (var elem in Element.Elements)
                VariableExtractionFactory.ExtractVariables(elem, variables, Parms);

            variables.Remove(itVar.Name);
            foreach (var extractedVariable in variables.Values)
            {
                extractedVariable.ConvertVarNameToLink(itVar);
                itVar.ConvertVarNameToLink(extractedVariable);
            }
        }

        private static void ExtractVar(IDictionary<string, ExtractedVariable> variables, AbstractConditionPart v, ExtractedVariable itVar)
        {
            var myVar = v as VariableConditionPart;
            if (myVar != null)
            {
                NoteVar(variables, myVar.VariableName, "0", false, itVar);
                return;
            }

            var opPart = v as OperationConditionPart;
            if (opPart != null)
            {
                var opPartLeft = opPart.LeftSide as OperationConditionPart;
                var opPartRight = opPart.RightSide as OperationConditionPart;

                if (opPartLeft != null)
                    ExtractVar(variables, opPartLeft, itVar);

                if (opPartRight != null)
                    ExtractVar(variables, opPartRight, itVar);

                var opPartLeftV = opPart.LeftSide as VariableConditionPart;

                var opPartRightV = opPart.RightSide as VariableConditionPart;

                if (opPartLeftV != null && opPartRightV != null)
                {
                    NoteVar(variables, opPartLeftV.VariableName, "{" + opPartRightV.VariableName + "}", false, itVar);
                    NoteVar(variables, opPartRightV.VariableName, "{" + opPartLeftV.VariableName + "}", false, itVar);
                }
                else if (opPartLeftV != null)
                    NoteVars(opPartLeftV, opPart.RightSide, variables, false, itVar);
                else if (opPartRightV != null)
                    NoteVars(opPartRightV, opPart.LeftSide, variables, false, itVar);
            }
        }
    }
}
