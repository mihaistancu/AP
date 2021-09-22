using System.Collections.Generic;

namespace AP.Routing
{
    public class RoutingRuleStorage
    {
        private List<RoutingRule> rules = new List<RoutingRule>();

        public RoutingRuleStorage()
        {
            rules.Add(new RoutingRule
            {
                Id = "1"
            });

            rules.Add(new RoutingRule
            {
                Id = "2"
            });
        }

        public RoutingRule[] GetAll()
        {
            return rules.ToArray();
        }

        public void Add(RoutingRule rule)
        {
            rules.Add(rule);
        }
    }
}
