using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Com.Ericmas001.Common;
using Com.Ericmas001.XmTemplating.Attributes;
using Com.Ericmas001.XmTemplating.Enums;

namespace Com.Ericmas001.XmTemplating.Deserialization.Util
{
    public static class TemplateDeserializationFactory
    {
        private static Dictionary<string, TemplateCommandEnum> m_Commands;
        private static Dictionary<TemplateCommandEnum, Type> m_CommandDeserializers;
        public static AbstractTemplateElement Deserialize(string command, AbstractTemplateElement root, TemplateTokenizer tokenizer, TemplateDeserializationParms parms)
        {

            var cmd = GetCommand(command);

            var deserializer = GetDeserializer(command, cmd);

            deserializer.Initialize(parms,cmd);

            return deserializer.DeserializeElement(tokenizer, root);

        }

        private static TemplateCommandEnum GetCommand(string command)
        {
            var commandName = command.ToUpper();
            if (m_Commands == null)
                InitCommands();
            if (!m_Commands.ContainsKey(commandName))
                throw new ArgumentOutOfRangeException(nameof(command), $"Command {commandName} not recognized");
            var ce = m_Commands[commandName];
            return ce;
        }

        private static AbstractTemplateDeserializer GetDeserializer(string command, TemplateCommandEnum cmd)
        {
            var commandName = command.ToUpper();
            if (m_CommandDeserializers == null)
                InitCommandDeserializers();

            if (!m_CommandDeserializers.ContainsKey(cmd))
                throw new ArgumentOutOfRangeException(nameof(command), $"Command {commandName} ({cmd}) not deserializable");

            var type = m_CommandDeserializers[cmd];
            ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);
            AbstractTemplateDeserializer instance = (AbstractTemplateDeserializer) ctor?.Invoke(new object[0]);
            if (instance == null)
                throw new ArgumentOutOfRangeException(nameof(command), $"Deserializer for {commandName} ({cmd}) not instanciable");
            return instance;
        }

        private static void InitCommandDeserializers()
        {
            m_CommandDeserializers = new Dictionary<TemplateCommandEnum, Type>();
            foreach (var t in Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof (AbstractTemplateDeserializer).IsAssignableFrom(t)))
            {
                var att = t.GetCustomAttributes(typeof (TemplateCommandAttribute), true).FirstOrDefault() as TemplateCommandAttribute;
                if (att == null)
                    continue;
                foreach (var c in att.Commands)
                    m_CommandDeserializers.Add(c, t);
            }
        }

        private static void InitCommands()
        {
            m_Commands = new Dictionary<string, TemplateCommandEnum>();
            foreach (var tc in EnumUtil.AllValues<TemplateCommandEnum>())
            {
                var att = tc.GetAttribute<TemplateCommandNameAttribute>();
                if (att == null)
                    continue;
                foreach (var commandName in att.CommandNames)
                    m_Commands.Add(commandName, tc);
            }
        }
    }
}
