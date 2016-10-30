using System.Collections.Generic;
using System.IO;
using Com.Ericmas001.XmTemplating.Serialization.Util;

namespace Com.Ericmas001.XmTemplating.Serialization
{
    public abstract class AbstractTemplateSerializer<T> where T:AbstractTemplateElement
    {
        public T Element { get; private set; }
        public TemplateSerializationParms Parms { get; private set; }
        public IDictionary<string, string> Variables { get; private set; }
        public IDictionary<string, IEnumerable<string>> Arrays { get; private set; }

        public AbstractTemplateSerializer(T element, IDictionary<string, string> variables, IDictionary<string, IEnumerable<string>> arrays, TemplateSerializationParms parms)
        {
            Element = element;
            Variables = variables;
            Arrays = arrays;
            Parms = parms;
        }

        public abstract void Serialize(TextWriter tw);
    }
}
