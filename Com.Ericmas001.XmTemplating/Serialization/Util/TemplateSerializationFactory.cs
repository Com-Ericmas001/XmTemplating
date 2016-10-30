using System;
using System.Collections.Generic;
using System.IO;

namespace Com.Ericmas001.XmTemplating.Serialization.Util
{
    public static class TemplateSerializationFactory
    {
        public static void Serialize(TextWriter tw, AbstractTemplateElement element, IDictionary<string,string> vars, IDictionary<string, IEnumerable<string>> arrays, TemplateSerializationParms parms)
        {
            var cloneVars = new Dictionary<string, string>(vars);
            var cloneArrays = new Dictionary<string, IEnumerable<string>>(arrays);

            if (element is StaticTemplateElement)
                new StaticTemplateSerializer((StaticTemplateElement)element, cloneVars, cloneArrays, parms).Serialize(tw);

            else if (element is ConditionalTemplateElement)
                new ConditionalTemplateSerializer((ConditionalTemplateElement)element, cloneVars, cloneArrays, parms).Serialize(tw);

            else if (element is EnumeratorTemplateElement)
                new EnumeratorTemplateSerializer((EnumeratorTemplateElement)element, cloneVars, cloneArrays, parms).Serialize(tw);

            else if (element is RangeTemplateElement)
                new RangeTemplateSerializer((RangeTemplateElement)element, cloneVars, cloneArrays, parms).Serialize(tw);

            else if (element is EvaluateTemplateElement)
                new EvaluateTemplateSerializer((EvaluateTemplateElement)element, cloneVars, cloneArrays, parms).Serialize(tw);

            else if (element is DefineTemplateElement)
                new DefineTemplateSerializer((DefineTemplateElement)element, vars, arrays, parms).Serialize(tw);

            else
                throw new ArgumentOutOfRangeException("element", string.Format("Serializer not found for element of type {0}", element.GetType()));
        }
    }
}
