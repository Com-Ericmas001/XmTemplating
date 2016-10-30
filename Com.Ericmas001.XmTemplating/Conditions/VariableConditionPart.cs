namespace Com.Ericmas001.XmTemplating.Conditions
{
    public class VariableConditionPart : AbstractConditionPart
    {
        public string VariableName { get; set; }

        public override string ToString()
        {
            return "{" + VariableName + "}";
        }
    }
}
