using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AP.Portal.WebApi
{
    public class RoutingRulesController : ApiController
    {
        private static List<RoutingRule> routingRules = new List<RoutingRule>(); 

        public IEnumerable<RoutingRule> Get()
        {
            return routingRules;
        }

        public RoutingRule Get(string id)
        {
            return routingRules.Single(r => r.Id == id);
        }

        public void Post([FromBody] RoutingRule rule)
        {
            routingRules.Add(rule);
        }

        public void Put([FromBody] RoutingRule rule)
        {
            Delete(rule.Id);
            routingRules.Add(rule);
        }

        public void Delete(string id)
        {
            var existingRule = routingRules.Single(r => r.Id == id);
            routingRules.Remove(existingRule);
        }
    }
}
