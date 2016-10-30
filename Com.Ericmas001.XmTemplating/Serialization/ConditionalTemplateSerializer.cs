﻿using System.Collections.Generic;
using System.IO;
using Com.Ericmas001.XmTemplating.Serialization.Util;

namespace Com.Ericmas001.XmTemplating.Serialization
{
    public class ConditionalTemplateSerializer : AbstractTemplateSerializer<ConditionalTemplateElement>
    {
        public ConditionalTemplateSerializer(ConditionalTemplateElement element, IDictionary<string, string> variables, IDictionary<string, IEnumerable<string>> arrays, TemplateSerializationParms parms) : base(element, variables, arrays, parms)
        {
        }

        public override void Serialize(TextWriter tw)
        {
            if (Element.Condition.Evaluate(Variables))
            {
                foreach (var elem in Element.ConditionTrueElements)
                    TemplateSerializationFactory.Serialize(tw, elem, Variables, Arrays, Parms);
                return;
            }

            if (Element.ConditionFalseElements != null)
            {
                foreach (var elem in Element.ConditionFalseElements)
                    TemplateSerializationFactory.Serialize(tw, elem, Variables, Arrays, Parms);
            }
        }
    }
}