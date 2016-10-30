using Com.Ericmas001.Common.Attributes;

namespace Com.Ericmas001.XmTemplating.VariableExtraction.Util
{
    public enum VariableTypeEnum
    {
        [DisplayName("")]
        Unknown,

        [DisplayName("Texte")]
        Text,

        [DisplayName("Nombre")]
        Number,

        [DisplayName("Vrai/Faux")]
        Boolean,

        [DisplayName("Élément de liste")]
        ListItem
    }
}
