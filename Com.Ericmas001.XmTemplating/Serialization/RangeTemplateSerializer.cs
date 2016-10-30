﻿using System.Collections.Generic;
using System.IO;
using Com.Ericmas001.XmTemplating.Conditions;
using Com.Ericmas001.XmTemplating.Conditions.Util;
using Com.Ericmas001.XmTemplating.Serialization.Util;

namespace Com.Ericmas001.XmTemplating.Serialization
{
    public class RangeTemplateSerializer : AbstractTemplateSerializer<RangeTemplateElement>
    {
        public RangeTemplateSerializer(RangeTemplateElement element, IDictionary<string, string> variables, IDictionary<string, IEnumerable<string>> arrays, TemplateSerializationParms parms) : base(element, variables, arrays, parms)
        {
        }

        public override void Serialize(TextWriter tw)
        {
            var varPart = Element.Variable;

            var min = int.Parse(ConditionSerializer.Serialize(Element.Minimum, Variables));
            var max = int.Parse(ConditionSerializer.Serialize(Element.Maximum, Variables));
            if (!Element.InludeMaximum)
                max--;

            var vars = new Dictionary<string, string>(Variables);
            vars.Add(varPart.VariableName, null);
            for (int i = min; i <= max; ++i)
            {
                string value = i.ToString();
                vars[varPart.VariableName] = value;

                foreach (var elem in Element.Elements)
                    TemplateSerializationFactory.Serialize(tw, elem, vars, Arrays, Parms);
            }
        }

        private void SerializeVarPart(TextWriter tw, VariableConditionPart varPart)
        {
            string enumerationVariable = varPart.VariableName;

            var arrs = new Dictionary<string, IEnumerable<string>>(Arrays);
            arrs.Remove(enumerationVariable);

            var vars = new Dictionary<string, string>(Variables);
            vars.Add(enumerationVariable, null);

            foreach (var value in Arrays[enumerationVariable])
            {
                vars[enumerationVariable] = value;

                foreach (var elem in Element.Elements)
                    TemplateSerializationFactory.Serialize(tw, elem, vars, arrs, Parms);
            }
        }
    }
}