using System.Collections.Generic;
using System.IO;
using System.Linq;
using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.Conditions.Util;
using Com.Ericmas001.XmTemplating.Enums;
using Com.Ericmas001.XmTemplating.Serialization.Util;

namespace Com.Ericmas001.XmTemplating.Serialization
{
    public class EnumeratorTemplateSerializer : AbstractTemplateSerializer<EnumeratorTemplateElement>
    {
        public override void Serialize(TextWriter tw)
        {
            var varPart = Element.EnumerationCondition as VariableConditionPart;
            if(varPart != null)
                SerializeVarPart(tw, varPart);

            var opPart = Element.EnumerationCondition as OperationConditionPart;
            if (opPart != null && opPart.Operator == ConditionPartOperatorEnum.In && opPart.LeftSide is VariableConditionPart)
            {
                var vars = new Dictionary<string, string>(Variables);
                var enumerationVariable = ((VariableConditionPart)opPart.LeftSide).VariableName;
                vars.Add(enumerationVariable, null);

                IEnumerable<string> values = new string[0];

                if (opPart.RightSide is GroupedConditionPart)
                {
                    values = ((GroupedConditionPart) opPart.RightSide).Values.Select(val => ConditionSerializer.Serialize(val, Variables, Arrays));
                }
                else if (opPart.RightSide is VariableConditionPart)
                {
                    string key = ((VariableConditionPart) opPart.RightSide).VariableName;
                    if (Arrays.ContainsKey(key))
                        values = Arrays[key];
                }
                foreach (var value in values)
                {
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
