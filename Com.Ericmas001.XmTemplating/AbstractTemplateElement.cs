namespace Com.Ericmas001.XmTemplating
{
    public abstract class AbstractTemplateElement
    {
        public AbstractTemplateElement Parent { get; private set; }

        protected AbstractTemplateElement(AbstractTemplateElement parent)
        {
            Parent = parent;
        }
    }
}
