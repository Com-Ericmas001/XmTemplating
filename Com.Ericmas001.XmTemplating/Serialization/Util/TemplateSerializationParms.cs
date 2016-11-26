namespace Com.Ericmas001.XmTemplating.Serialization.Util
{
    public class TemplateSerializationParms
    {
        public bool RemoveEmptyLines { get; set; }
        public bool TrimEndOfLines { get; set; }
        public uint MaxLineLength { get; set; }

        public TemplateSerializationParms()
        {
            TrimEndOfLines = true;
            RemoveEmptyLines = true;
            MaxLineLength = 0;
        }
    }
}
