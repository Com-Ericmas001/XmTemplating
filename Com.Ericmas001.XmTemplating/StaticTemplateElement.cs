namespace Com.Ericmas001.XmTemplating
{
    public class StaticTemplateElement : AbstractTemplateElement
    {
        public string Content { get; set; }

        public StaticTemplateElement(AbstractTemplateElement parent) : base(parent)
        {
        }
    }
}
