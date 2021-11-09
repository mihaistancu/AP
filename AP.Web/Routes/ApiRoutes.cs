using AP.Configuration.Routing.API;
using AP.Http;
using AP.Web.Authorization;

namespace AP.Web.Routes
{
    public class ApiRoutes
    {
        private Authorizer authorizer;
        private GetAllRoutingRulesApi getAllRoutingRules;
        private AddRoutingRuleApi addRoutingRule;
        private UpdateRoutingRuleApi updateRoutingRule;
        private DeleteRoutingRuleApi deleteRoutingRule;

        public ApiRoutes(
            Authorizer authorizer,
            GetAllRoutingRulesApi getAllRoutingRules,
            AddRoutingRuleApi addRoutingRule,
            UpdateRoutingRuleApi updateRoutingRule,
            DeleteRoutingRuleApi deleteRoutingRule)
        {
            this.authorizer = authorizer;
            this.getAllRoutingRules = getAllRoutingRules;
            this.addRoutingRule = addRoutingRule;
            this.updateRoutingRule = updateRoutingRule;
            this.deleteRoutingRule = deleteRoutingRule;
        }

        public void Apply(IHttpServer server)
        {
            server.Map("GET", "/api/routing-rules", getAllRoutingRules.Handle, authorizer.AllowOperators);
            server.Map("POST", "/api/routing-rules", addRoutingRule.Handle, authorizer.AllowOperators);
            server.Map("PUT", "/api/routing-rules/{id}", updateRoutingRule.Handle, authorizer.AllowOperators);
            server.Map("DELETE", "/api/routing-rules/{id}", deleteRoutingRule.Handle, authorizer.AllowOperators);
        }
    }
}
