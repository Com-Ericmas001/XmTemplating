namespace Com.Ericmas001.XmTemplating.Conditions
{
    public class LiteralConditionPart : AbstractConditionPart
    {
        public string Value { get; set; }

        public override string ToString()
        {
            return "\"" + Value + "\"";
        }
    }
}
