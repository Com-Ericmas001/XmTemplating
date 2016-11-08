using System.Collections.Generic;
using System.IO;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.Conditions.Util;
using Com.Ericmas001.XmTemplating.Enums;
using Com.Ericmas001.XmTemplating.Serialization.Util;

namespace Com.Ericmas001.XmTemplating.Serialization
{
    public class EnumeratorTemplateSerializer : AbstractTemplateSerializer<EnumeratorTemplateElement>
    {
        public EnumeratorTemplateSerializer(EnumeratorTemplateElement element, IDictionary<string, string> variables, IDictionary<string, IEnumerable<string>> arrays, TemplateSerializationParms parms) : base(element, variables, arrays, parms)
        {
        }

        public override void Serialize(TextWriter tw)
        {
            var varPart = Element.EnumerationCondition as VariableConditionPart;
            if(varPart != null)
                SerializeVarPart(tw, varPart);

            var opPart = Element.EnumerationCondition as OperationConditionPart;
            if (opPart != null && opPart.Operator == ConditionPartOperatorEnum.In && opPart.LeftSide is VariableConditionPart && opPart.RightSide is GroupedConditionPart)
            {
                var vars = new Dictionary<string, string>(Variables);
                var enumerationVariable = ((VariableConditionPart)opPart.LeftSide).VariableName;
                vars.Add(enumerationVariable, null);
                foreach (var val in ((GroupedConditionPart)opPart.RightSide).Values)
                {
                    string value = ConditionSerializer.Serialize(val, Variables);
                    vars[enumerationVariable] = value;

                    foreach (var elem in Element.Elements)
                        TemplateSerializationFactory.Serialize(tw, elem, vars, Arrays, Parms);
                }
            }
        }

        private void SerializeVarPart(TextWriter tw, VariableConditionPart varPart)
        {
            string enumerationVariable = varPart.VariableName;

            var arrs = new Dictionary<string, IEnumerable<string>>(Arrays);
            arrs.Remove(enumerationVariable);

            var vars = new Dictionary<string, string>(Variables)
            {
                {enumerationVariable, null}
            };

            foreach (var value in Arrays[enumerationVariable])
            {
                vars[enumerationVariable] = value;
                foreach (var elem in Element.Elements)
                    TemplateSerializationFactory.Serialize(tw, elem, vars, arrs, Parms);
            }
        }
    }
}
