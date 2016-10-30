using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.XmTemplating.Deserialization.Util;

namespace Com.Ericmas001.XmTemplating.Deserialization
{
    public abstract class AbstractTemplateDeserializer<T> where T: AbstractTemplateElement
    {
        public TemplateDeserializationParms Parms { get; private set; }

        protected AbstractTemplateDeserializer(TemplateDeserializationParms parms)
        {
            Parms = parms;
        }

        public abstract T Deserialize(TemplateTokenizer tokenizer, AbstractTemplateElement root );

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
