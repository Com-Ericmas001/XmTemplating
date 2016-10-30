using Com.Ericmas001.Common.Attributes;

namespace Com.Ericmas001.XmTemplating.VariableExtraction.Util
{
    public enum VariableTypeEnum
    {
        Unknown,

        [DisplayName("Text")]
        [FrDisplayName("Texte")]
        Text,

        [DisplayName("Number")]
        [FrDisplayName("Nombre")]
        Number,

        [DisplayName("Boolean")]
        [FrDisplayName("Vrai/Faux")]
        Boolean,

        [DisplayName("List Item")]
        [FrDisplayName("Élément de liste")]
        ListItem
    }
}
