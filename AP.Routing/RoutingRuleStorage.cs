using System.Collections.Generic;
using System.Linq;

namespace AP.Routing
{
    public class RoutingRuleStorage
    {
        private List<RoutingRule> rules = new List<RoutingRule>();

        public RoutingRule[] GetAll()
        {
            return rules.ToArray();
        }

        public void Delete(string id)
        {
            var rule = rules.Single(r => r.Id == id);
            rules.Remove(rule);
        }

        public void Add(RoutingRule rule)
        {
            rules.Add(rule);
        }

        public void Update(string id, RoutingRule rule)
        {
            var existingRule = rules.Single(r => r.Id == id);
            existingRule.Address = rule.Address;
        }
    }
}
