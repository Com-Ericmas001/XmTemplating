namespace Com.Ericmas001.XmTemplating
{
    public abstract class AbstractTemplateElement
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        private AbstractTemplateElement Parent { get; set; }

        protected AbstractTemplateElement(AbstractTemplateElement parent)
        {
            Parent = parent;
        }
    }
}
