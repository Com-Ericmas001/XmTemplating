using System.Collections.Generic;

namespace Com.Ericmas001.XmTemplating
{
    public class XmTemplateElement : AbstractTemplateElement
    {
        public IEnumerable<AbstractTemplateElement> Elements { get; set; }

        public string TemplateSource { get; set; }

        public XmTemplateElement() : base(null)
        {
        }
    }
}
