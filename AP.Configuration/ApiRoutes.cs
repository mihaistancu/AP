using AP.Configuration.Routing.API;
using AP.IO;

namespace AP.Configuration
{
    public class ApiRoutes
    {
        private GetAllRoutingRulesApi getAllRoutingRules;
        private AddRoutingRuleApi addRoutingRule;
        private UpdateRoutingRuleApi updateRoutingRule;
        private DeleteRoutingRuleApi deleteRoutingRule;

        public ApiRoutes(
            GetAllRoutingRulesApi getAllRoutingRules,
            AddRoutingRuleApi addRoutingRule,
            UpdateRoutingRuleApi updateRoutingRule,
            DeleteRoutingRuleApi deleteRoutingRule)
        {
            this.getAllRoutingRules = getAllRoutingRules;
            this.addRoutingRule = addRoutingRule;
            this.updateRoutingRule = updateRoutingRule;
            this.deleteRoutingRule = deleteRoutingRule;
        }

        public void Apply(IWebServer server)
        {
            server.Map("GET", "/api/routing-rules", getAllRoutingRules);
            server.Map("POST", "/api/routing-rules", addRoutingRule);
            server.Map("PUT", "/api/routing-rules/{id}", updateRoutingRule);
            server.Map("DELETE", "/api/routing-rules/{id}", deleteRoutingRule);
        }
    }
}
