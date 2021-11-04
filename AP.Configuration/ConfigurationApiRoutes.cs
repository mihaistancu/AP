using AP.Configuration.Routing.API;
using AP.Http;

namespace AP.Configuration
{
    public class ConfigurationApiRoutes
    {
        private GetAllRoutingRulesApi getAllRoutingRules;
        private AddRoutingRuleApi addRoutingRule;
        private UpdateRoutingRuleApi updateRoutingRule;
        private DeleteRoutingRuleApi deleteRoutingRule;

        public ConfigurationApiRoutes(
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

        public void Apply(IHttpServer server)
        {
            server.Map("GET", "/api/routing-rules", getAllRoutingRules.Handle);
            server.Map("POST", "/api/routing-rules", addRoutingRule.Handle);
            server.Map("PUT", "/api/routing-rules/{id}", updateRoutingRule.Handle);
            server.Map("DELETE", "/api/routing-rules/{id}", deleteRoutingRule.Handle);
        }
    }
}
