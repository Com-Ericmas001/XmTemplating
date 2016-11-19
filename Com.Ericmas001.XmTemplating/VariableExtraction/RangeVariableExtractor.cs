using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.VariableExtraction.Util;

namespace Com.Ericmas001.XmTemplating.VariableExtraction
{
    public class RangeVariableExtractor : AbstractVariableExtractor<RangeTemplateElement>
    {
        public override void ExtractVariables(IDictionary<string, ExtractedVariable> variables)
        {
            var minV = ExtractVar(variables, Element.Minimum);
            var maxV = ExtractVar(variables, Element.Maximum);
            var itVar = GetVar(variables, Element.Variable.VariableName);

            if (minV != null && maxV != null)
            {
                minV.Links.Add(itVar);
                maxV.Links.Add(itVar);
                itVar.Links.Add(minV);
                itVar.Links.Add(maxV);
            }

            foreach (var elem in Element.Elements)
                VariableExtractionFactory.ExtractVariables(elem, variables, Parms);

            variables.Remove(itVar.Name);
            foreach (var extractedVariable in variables.Values)
            {
                extractedVariable.ConvertVarNameToLink(itVar);
                itVar.ConvertVarNameToLink(extractedVariable);
            }
        }

        private static ExtractedVariable ExtractVar(IDictionary<string, ExtractedVariable> variables, AbstractConditionPart v)
        {
            var myVar = v as VariableConditionPart;
            if (myVar != null)
            {
                NoteVar(variables, myVar.VariableName, "0");
                return GetVar(variables,myVar.VariableName);
            }

            var opPart = v as OperationConditionPart;
            if (opPart != null)
            {
                var opPartLeft = opPart.LeftSide as OperationConditionPart;
                var opPartRight = opPart.RightSide as OperationConditionPart;

                if (opPartLeft != null)
                    ExtractVar(variables, opPartLeft);

                if (opPartRight != null)
                    ExtractVar(variables, opPartRight);

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
            return null;
        }
    }
}
