using System.Collections.Generic;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.VariableExtraction.Util;

namespace Com.Ericmas001.XmTemplating.VariableExtraction
{
    public abstract class AbstractVariableExtractor<T> : AbstractVariableExtractor where T : AbstractTemplateElement
    {
        public new T Element => (T)base.Element;
    }
    public abstract class AbstractVariableExtractor
    {
        public VariableExtractionParms Parms { get; private set; }
        public AbstractTemplateElement Element { get; private set; }

        public virtual void Initialize(AbstractTemplateElement element, VariableExtractionParms parms)
        {
            Parms = parms;
            Element = element;
        }

        public abstract void ExtractVariables(IDictionary<string, ExtractedVariable> variables );

        protected static void NoteVar(IDictionary<string, ExtractedVariable> variables, string key, string value, bool fromList = false, ExtractedVariable linkedVar = null)
        {
            var v = GetVar(variables, key);
            v.AddValue(value);
            if (fromList)
                v.IsUsingListValues = true;
            if (linkedVar != null)
            {
                v.Links.Add(linkedVar);
                linkedVar.Links.Add(v);
            }
        }
        protected static void NoteArrayVar(IDictionary<string, ExtractedVariable> variables, string key)
        {
            GetVar(variables, key).IsArray = true;
        }

        protected static ExtractedVariable GetVar(IDictionary<string, ExtractedVariable> variables, string key)
        {
            if (!variables.ContainsKey(key))
                variables.Add(key, new ExtractedVariable(key));
            return variables[key];
        }

        protected static void NoteVars(VariableConditionPart opPartLeftV, AbstractConditionPart opPart, IDictionary<string, ExtractedVariable> variables, bool fromList = false, ExtractedVariable linkedVar = null)
        {
            var opPartRightL = opPart as LiteralConditionPart;
            var opPartRightG = opPart as GroupedConditionPart;

            if (opPartRightL != null)
                NoteVar(variables, opPartLeftV.VariableName, opPartRightL.Value, fromList, linkedVar);
            else if (opPartRightG != null)
                foreach (var cp in opPartRightG.Values)
                    NoteVars(opPartLeftV, cp, variables, true, linkedVar);
        }
    }
}
