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
        private static IDictionary<Type, KeyValuePair<Type,bool>> m_CommandSerializers;
        public static void Serialize(TextWriter tw, AbstractTemplateElement element, IDictionary<string,string> vars, IDictionary<string, IEnumerable<string>> arrays, TemplateSerializationParms parms)
        {
            if (m_CommandSerializers == null)
                m_CommandSerializers = InitCommandSerializers();

            if (!m_CommandSerializers.ContainsKey(element.GetType()))
                throw new ArgumentOutOfRangeException(nameof(element), $"ElementType {element.GetType()} not serializable");
            
            var typeInfo = m_CommandSerializers[element.GetType()];
            var ctor = typeInfo.Key.GetConstructor(Type.EmptyTypes);
            var instance = (AbstractTemplateSerializer)ctor?.Invoke(new object[0]);
            if (instance == null)
                throw new ArgumentOutOfRangeException(nameof(element), $"Serializer for {element.GetType()} not instanciable");

            if (typeInfo.Value)
            {
                var cloneVars = new Dictionary<string, string>(vars);
                var cloneArrays = new Dictionary<string, IEnumerable<string>>(arrays);
                instance.Initialize(element, cloneVars, cloneArrays, parms);
            }
            else
                instance.Initialize(element, vars, arrays, parms);

            instance.Serialize(tw);
        }
        private static IDictionary<Type, KeyValuePair<Type, bool>> InitCommandSerializers()
        {
            var cs = new Dictionary<Type, KeyValuePair<Type, bool>>();
            foreach (var t in Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(AbstractTemplateSerializer).IsAssignableFrom(t)))
            {
                var att = t.GetCustomAttributes(typeof(TemplateElementAttribute), true).FirstOrDefault() as TemplateElementAttribute;
                if (att == null)
                    continue;
                cs.Add(att.Element, new KeyValuePair<Type, bool>(t, att.UseClones));
            }
            return cs;
        }
    }
}
