using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Serialization;

namespace Com.Ericmas001.XmTemplating.VariableExtraction.Util
{
    public static class VariableExtractionFactory
    {
        private static IDictionary<Type, TemplateElementVariableExtractorAttribute> m_CommandSerializers;
        public static void ExtractVariables(AbstractTemplateElement element, IDictionary<string, ExtractedVariable> variables, VariableExtractionParms parms)
        {
            if (m_CommandSerializers == null)
                m_CommandSerializers = InitCommandSerializers();

            if (!m_CommandSerializers.ContainsKey(element.GetType()))
                throw new ArgumentOutOfRangeException(nameof(element), $"ElementType {element.GetType()} not serializable");

            var typeInfo = m_CommandSerializers[element.GetType()];
            var ctor = typeInfo.VariableExtractor.GetConstructor(Type.EmptyTypes);
            var instance = (AbstractVariableExtractor)ctor?.Invoke(new object[0]);
            if (instance == null)
                throw new ArgumentOutOfRangeException(nameof(element), $"Serializer for {element.GetType()} not instanciable");
            
            instance.Initialize(element, parms);
            instance.ExtractVariables(variables);
        }

        private static IDictionary<Type, TemplateElementVariableExtractorAttribute> InitCommandSerializers()
        {
            var cs = new Dictionary<Type, TemplateElementVariableExtractorAttribute>();
            foreach (var t in Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(AbstractTemplateElement).IsAssignableFrom(t)))
            {
                var att = t.GetCustomAttributes(typeof(TemplateElementVariableExtractorAttribute), true).FirstOrDefault() as TemplateElementVariableExtractorAttribute;
                if (att == null)
                    continue;
                cs.Add(t, att);
            }
            return cs;
        }
    }
}
