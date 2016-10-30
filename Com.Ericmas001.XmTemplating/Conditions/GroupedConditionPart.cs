using System.Collections.Generic;
using System.Linq;

namespace Com.Ericmas001.XmTemplating.Conditions
{
    public class GroupedConditionPart : AbstractConditionPart
    {
        public IEnumerable<AbstractConditionPart> Values { get; set; }

        public override string ToString()
        {
            return "(" + string.Join(", ", Values.Select(x => x.ToString())) + ")";
        }
    }
}
