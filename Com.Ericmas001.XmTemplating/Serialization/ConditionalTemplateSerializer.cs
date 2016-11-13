﻿using System.Collections.Generic;
using System.IO;
using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Conditions.Util;
using Com.Ericmas001.XmTemplating.Serialization.Util;

namespace Com.Ericmas001.XmTemplating.Serialization
{
    [TemplateElement(typeof(ConditionalTemplateElement))]
    public class ConditionalTemplateSerializer : AbstractTemplateSerializer<ConditionalTemplateElement>
    {
        public ConditionalTemplateSerializer(ConditionalTemplateElement element, IDictionary<string, string> variables, IDictionary<string, IEnumerable<string>> arrays, TemplateSerializationParms parms) : base(element, variables, arrays, parms)
        {
        }

        public override void Serialize(TextWriter tw)
        {
            if (ConditionSerializer.Serialize(Element.Condition, new Dictionary<string, string>(Variables), new Dictionary<string, IEnumerable<string>>(Arrays)) == true.ToString())
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
