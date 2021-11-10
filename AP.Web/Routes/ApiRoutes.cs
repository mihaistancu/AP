using AP.Http;

namespace AP.Web.Routes
{
    public class ApiRoutes
    {
        private HttpHandler authenticate;
        private HttpHandler getAllRoutingRules;
        private HttpHandler addRoutingRule;
        private HttpHandler updateRoutingRule;
        private HttpHandler deleteRoutingRule;
        private HttpHandler createGroupWithInstitution;

        public ApiRoutes(
            HttpHandler authenticate,
            HttpHandler getAllRoutingRules,
            HttpHandler addRoutingRule,
            HttpHandler updateRoutingRule,
            HttpHandler deleteRoutingRule, 
            HttpHandler createGroupWithInstitution)
        {
            this.authenticate = authenticate;

            this.getAllRoutingRules = getAllRoutingRules;
            this.addRoutingRule = addRoutingRule;
            this.updateRoutingRule = updateRoutingRule;
            this.deleteRoutingRule = deleteRoutingRule;
            this.createGroupWithInstitution = createGroupWithInstitution;
        }

        public void Apply(IHttpServer server)
        {
            server.Map("POST", "/api/login", authenticate);

            server.Map("GET", "/api/routing-rules", getAllRoutingRules);
            server.Map("POST", "/api/routing-rules", addRoutingRule);
            server.Map("PUT", "/api/routing-rules/{id}", updateRoutingRule);
            server.Map("DELETE", "/api/routing-rules/{id}", deleteRoutingRule);

            server.Map("POST", "/api/groups", createGroupWithInstitution);
        }
    }
}
