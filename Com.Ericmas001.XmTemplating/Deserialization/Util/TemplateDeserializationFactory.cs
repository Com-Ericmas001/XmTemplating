using System;

namespace Com.Ericmas001.XmTemplating.Deserialization.Util
{
    public static class TemplateDeserializationFactory
    {
        public static AbstractTemplateElement Deserialize(string command, AbstractTemplateElement root, TemplateTokenizer tokenizer, TemplateDeserializationParms parms)
        {
            switch (command.ToUpper())
            {
                case "IF":
                    return new ConditionalTemplateDeserializer(parms).Deserialize(tokenizer, root);
                case "FOREACH":
                    return new EnumeratorTemplateDeserializer(parms).Deserialize(tokenizer, root);
                case "FOR":
                    return new RangeTemplateDeserializer(parms).Deserialize(tokenizer, root);
                case "EVAL":
                    return new EvaluateTemplateDeserializer(parms).Deserialize(tokenizer, root);
                case "DEFINE":
                    return new DefineTemplateDeserializer(parms, false).Deserialize(tokenizer, root);
                case "DEFINE_ARRAY":
                    return new DefineTemplateDeserializer(parms, true).Deserialize(tokenizer, root);
                case "BR":
                    return new NewLineTemplateDeserializer(parms).Deserialize(tokenizer, root);
                default:
                    throw new ArgumentOutOfRangeException(nameof(command), $"Command {command.ToUpper()} not recognized");
            }
        }
    }
}
