using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Com.Ericmas001.XmTemplating.Attributes;

namespace Com.Ericmas001.XmTemplating.Serialization.Util
{
    public static class TemplateSerializationFactory
    {
        private static IDictionary<Type, TemplateElementSerializerAttribute> m_CommandSerializers;
        public static void Serialize(TextWriter tw, AbstractTemplateElement element, IDictionary<string,string> vars, IDictionary<string, IEnumerable<string>> arrays, TemplateSerializationParms parms)
        {
            if (m_CommandSerializers == null)
                m_CommandSerializers = InitCommandSerializers();

            if (!m_CommandSerializers.ContainsKey(element.GetType()))
                throw new ArgumentOutOfRangeException(nameof(element), $"ElementType {element.GetType()} not serializable");
            
            var typeInfo = m_CommandSerializers[element.GetType()];
            var ctor = typeInfo.Serializer.GetConstructor(Type.EmptyTypes);
            var instance = (AbstractTemplateSerializer)ctor?.Invoke(new object[0]);
            if (instance == null)
                throw new ArgumentOutOfRangeException(nameof(element), $"Serializer for {element.GetType()} not instanciable");

            if (typeInfo.UseClones)
            {
                var cloneVars = new Dictionary<string, string>(vars);
                var cloneArrays = new Dictionary<string, IEnumerable<string>>(arrays);
                instance.Initialize(element, cloneVars, cloneArrays, parms);
            }
            else
                instance.Initialize(element, vars, arrays, parms);

            instance.Serialize(tw);
        }

        private static IDictionary<Type, TemplateElementSerializerAttribute> InitCommandSerializers()
        {
            var cs = new Dictionary<Type, TemplateElementSerializerAttribute>();
            foreach (var t in Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(AbstractTemplateElement).IsAssignableFrom(t)))
            {
                var att = t.GetCustomAttributes(typeof(TemplateElementSerializerAttribute), true).FirstOrDefault() as TemplateElementSerializerAttribute;
                if (att == null)
                    continue;
                cs.Add(t, att);
            }
            return cs;
        }
    }
}
