using System.Collections.Generic;

namespace AP.Routing.Entities.Conditions
{
    public class All : ICondition
    {
        public List<ICondition> Children { get; set; }
    }
}
