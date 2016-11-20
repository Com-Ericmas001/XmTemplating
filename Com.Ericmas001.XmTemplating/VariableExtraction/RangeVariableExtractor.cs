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
            itVar.Values.Add("0");

            var minV = ExtractVar(variables, Element.Minimum);
            if (minV != null)
            {
                minV.Links.Add(itVar);
                itVar.Links.Add(minV);
            }
            var minL = Element.Minimum as LiteralConditionPart;
            if(minL != null)
                itVar.Values.Add(minL.Value);

            var maxV = ExtractVar(variables, Element.Maximum);
            if (maxV != null)
            {
                maxV.Links.Add(itVar);
                itVar.Links.Add(maxV);
            }
            var maxL = Element.Maximum as LiteralConditionPart;
            if (maxL != null)
                itVar.Values.Add(maxL.Value);

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
