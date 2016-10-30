using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.XmTemplating.Deserialization.Util;
using Com.Ericmas001.XmTemplating.Enums;

namespace Com.Ericmas001.XmTemplating.Deserialization
{
    public abstract class AbstractTemplateDeserializer<T> : AbstractTemplateDeserializer where T : AbstractTemplateElement
    {
        public abstract T Deserialize(TemplateTokenizer tokenizer, AbstractTemplateElement root);
        public override AbstractTemplateElement DeserializeElement(TemplateTokenizer tokenizer, AbstractTemplateElement root)
        {
            return Deserialize(tokenizer, root);
        }
    }
    public abstract class AbstractTemplateDeserializer
    {
        public TemplateDeserializationParms Parms { get; private set; }
        public TemplateCommandEnum Command { get; private set; }

        public virtual void Initialize(TemplateDeserializationParms parms, TemplateCommandEnum command)
        {
            Parms = parms;
            Command = command;
        }
        public abstract AbstractTemplateElement DeserializeElement(TemplateTokenizer tokenizer, AbstractTemplateElement root);

        protected IEnumerable<AbstractTemplateElement> FindElements(AbstractTemplateElement root, TemplateTokenizer tokenizer, params string[] delimitters)
        {
            var staticPart = tokenizer.AdvanceUntilChar('<');
            while (staticPart != null)
            {
                if (!string.IsNullOrEmpty(staticPart))
                    yield return new StaticTemplateElement(root) { Content = staticPart };

                tokenizer.Advance();
                var command = tokenizer.PeekUntilChar(' ');
                if (command == null || delimitters.Any(x => command.ToUpper().StartsWith(x)))
                    yield break;
                yield return TemplateDeserializationFactory.Deserialize(command, root, tokenizer, Parms);
                tokenizer.Advance();
                staticPart = tokenizer.AdvanceUntilChar('<');
            }
        }
    }
}
