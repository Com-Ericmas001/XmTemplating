using Com.Ericmas001.XmTemplating.Attributes;

namespace Com.Ericmas001.XmTemplating.Enums
{
    public enum VarAttributeEnum
    {
        Undefined,

        [ValueType(typeof(int))]
        [AvailableTo(VariableTypeEnum.Number)]
        MinValue,

        [ValueType(typeof(int))]
        [AvailableTo(VariableTypeEnum.Number)]
        MaxValue
    }
}
