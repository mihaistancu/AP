using AP.Configuration.Routing;
using System.Collections.Generic;
using System.Linq;

namespace AP.Routing
{
    public class RoutingRuleStorage : IRoutingRuleStorage
    {
        static int id;
        private List<RoutingRule> rules = new List<RoutingRule>();

        public RoutingRuleStorage()
        {
            rules.Add(new RoutingRule
            {
                Id = "1",
                Address = "a"
            });
        }

        public RoutingRule[] GetAll()
        {
            return rules.ToArray();
        }

        public void Delete(string id)
        {
            var rule = rules.Single(r => r.Id == id);
            rules.Remove(rule);
        }

        public RoutingRule Add(RoutingRule rule)
        {
            rule.Id = id++.ToString();
            rules.Add(rule);
            return rule;
        }

        public void Update(string id, RoutingRule rule)
        {
            var existingRule = rules.Single(r => r.Id == id);
            existingRule.Address = rule.Address;
        }
    }
}
