﻿using System.Collections.Generic;
using System.IO;
using Com.Ericmas001.XmTemplating.Conditions.Util;
using Com.Ericmas001.XmTemplating.Serialization.Util;

namespace Com.Ericmas001.XmTemplating.Serialization
{
    public class EvaluateTemplateSerializer : AbstractTemplateSerializer<EvaluateTemplateElement>
    {
        public EvaluateTemplateSerializer(EvaluateTemplateElement element, IDictionary<string, string> variables, IDictionary<string, IEnumerable<string>> arrays, TemplateSerializationParms parms) : base(element, variables, arrays, parms)
        {
        }

        public override void Serialize(TextWriter tw)
        {
            tw.Write(ConditionSerializer.Serialize(Element.Expression, new Dictionary<string, string>(Variables)));
        }
    }
}