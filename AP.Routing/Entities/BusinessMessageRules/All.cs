using System.Collections.Generic;

namespace AP.Routing.Entities.BusinessMessageRules
{
    public class All : IBusinessMessageRule
    {
        public List<IBusinessMessageRule> Children { get; set; }
    }
}
