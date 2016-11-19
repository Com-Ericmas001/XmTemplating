using System.Collections.Generic;
using System.IO;
using Com.Ericmas001.XmTemplating.Serialization.Util;

namespace Com.Ericmas001.XmTemplating.Serialization
{
    public abstract class AbstractTemplateSerializer<T> : AbstractTemplateSerializer where T : AbstractTemplateElement
    {
        public new T Element => (T) base.Element;
    }

    public abstract class AbstractTemplateSerializer
    {
        public AbstractTemplateElement Element { get; private set; }
        public TemplateSerializationParms Parms { get; private set; }
        public IDictionary<string, string> Variables { get; private set; }
        public IDictionary<string, IEnumerable<string>> Arrays { get; private set; }

        public virtual void Initialize(AbstractTemplateElement element, IDictionary<string, string> variables, IDictionary<string, IEnumerable<string>> arrays, TemplateSerializationParms parms)
        {
            Element = element;
            Variables = variables;
            Arrays = arrays;
            Parms = parms;
        }

        public abstract void Serialize(TextWriter tw);
    }
}
