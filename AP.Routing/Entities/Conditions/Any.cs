using System.Collections.Generic;

namespace AP.Routing.Entities.Conditions
{
    public class Any : ICondition
    {
        public List<ICondition> Children { get; set; }
    }
}
