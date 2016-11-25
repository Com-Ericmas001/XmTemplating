using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Com.Ericmas001.XmTemplating.Enums;

namespace Com.Ericmas001.XmTemplating.VariableExtraction.Util
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class ExtractedVariable
    {
        private List<string> m_Values = new List<string>();
        public string Name { get; private set; }
        public Guid Guid { get; private set; }
        public List<ExtractedVariable> Links { get; private set; }
        public bool IsArray { get; set; }
        public bool IsUsingListValues { get; set; }
        public bool IsLocal { get; set; }
        public VariableTypeEnum GuessedType { get; set; }

        public IEnumerable<string> Values => m_Values.ToArray();

        public ExtractedVariable(string name, params string[] initialValues)
        {
            m_Values.AddRange(initialValues);
            Name = name;
            Links = new List<ExtractedVariable>();
            Guid = Guid.NewGuid();
            IsLocal = false;
            IsUsingListValues = false;
        }

        public override string ToString()
        {
            return Name + ":" + Guid;
        }

        public void ConvertVarNameToLink(ExtractedVariable variable)
        {
            var name = "{" + variable.Name + "}";

            if (!Values.Contains(name))
                return;

            Links.Add(variable);
            m_Values.RemoveAll(x => x == name);
        }

        public void ExpandLinks()
        {
            var links = new List<ExtractedVariable>(new[] { this });
            NoteLinks(links, this);
            links.Remove(this);
            if (links.Any())
            {
                m_Values.AddRange(links.SelectMany(x => x.Values));
                IsUsingListValues = links.All(x => x.IsUsingListValues);
                m_Values = Values.Distinct().ToList();
                Links.Clear();
            }

        }
        public void AddValue(string value)
        {
            if(!m_Values.Contains(value))
                m_Values.Add(value);
        }
        public void GuessType()
        {
            GuessedType = GuessTypeInternal();
        }

        private VariableTypeEnum GuessTypeInternal()
        {

            if (!Values.Any())
                return VariableTypeEnum.Text;

            if (!IsUsingListValues && Values.All(v => v.ToCharArray().All(char.IsDigit)))
                return VariableTypeEnum.Number;

            bool bidonBool;
            if (Values.All(v => bool.TryParse(v, out bidonBool)))
                return VariableTypeEnum.Boolean;
            
            return VariableTypeEnum.ListItem;
        }

        private void NoteLinks(IList<ExtractedVariable> links, ExtractedVariable v)
        {
            foreach (var link in v.Links)
            {
                if (!links.Contains(link))
                {
                    links.Add(link);
                    NoteLinks(links, link);
                }
            }
        }
    }
}
