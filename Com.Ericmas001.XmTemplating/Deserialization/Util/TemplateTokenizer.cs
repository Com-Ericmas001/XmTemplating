using System.Linq;

namespace Com.Ericmas001.XmTemplating.Deserialization.Util
{
    public class TemplateTokenizer
    {
        private int m_CurrentIndex = 0;
        private readonly string m_CurrentTemplate;
        public TemplateTokenizer(string template)
        {
            m_CurrentTemplate = template;
        }

        public void Advance()
        {
            m_CurrentIndex++;
        }
        public string AdvanceUntilChar(params char[] chars)
        {
            if (m_CurrentIndex >= m_CurrentTemplate.Length)
                return null;
            int[] idexes = chars.Select(c => m_CurrentTemplate.IndexOf(c, m_CurrentIndex)).Where(i => i >= 0).ToArray();
            if (!idexes.Any())
                return AdvanceAndSubstring(m_CurrentTemplate.Length);
            return AdvanceAndSubstring(idexes.Min());
        }
        public void AdvanceWhileChar(params char[] chars)
        {
            while (chars.Contains(m_CurrentTemplate[m_CurrentIndex]))
                m_CurrentIndex++;
        }
        public char CurrentChar
        {
            get { return m_CurrentTemplate[m_CurrentIndex]; }
        }

        public string CurrentTemplate
        {
            get { return m_CurrentTemplate; }
        }

        public string CurrentString(int length)
        {
            return m_CurrentTemplate.Substring(m_CurrentIndex, length);
        }
        public string PeekUntilChar(params char[] chars)
        {
            if (m_CurrentIndex >= m_CurrentTemplate.Length)
                return null;
            int[] idexes = chars.Select(c => m_CurrentTemplate.IndexOf(c, m_CurrentIndex)).Where(i => i >= 0).ToArray();
            if (!idexes.Any())
                return m_CurrentTemplate.Substring(m_CurrentIndex);
            return m_CurrentTemplate.Substring(m_CurrentIndex, idexes.Min() - m_CurrentIndex);
        }

        private string AdvanceAndSubstring(int index)
        {
            int curIndex = m_CurrentIndex;
            m_CurrentIndex = index;
            return m_CurrentTemplate.Substring(curIndex, m_CurrentIndex - curIndex);
        }
    }
}
