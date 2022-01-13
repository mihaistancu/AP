using System.Collections.Generic;

namespace AP.Routing.Entities.BusinessMessageRules
{
    public class Any : IBusinessMessageRule
    {
        public List<IBusinessMessageRule> Children { get; set; }
    }
}
