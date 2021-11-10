using AP.Http;

namespace AP.Web.Routes
{
    public class ApiRoutes
    {
        private HttpHandler authenticate;
        private HttpHandler addRoutingRule;
        private HttpHandler updateRoutingRule;
        private HttpHandler deleteRoutingRule;
        private HttpHandler createGroupWithInstitution;
        private HttpHandler getAllGroups;

        public ApiRoutes(
            HttpHandler authenticate,
            HttpHandler addRoutingRule,
            HttpHandler updateRoutingRule,
            HttpHandler deleteRoutingRule,
            HttpHandler createGroupWithInstitution, 
            HttpHandler getAllGroups)
        {
            this.authenticate = authenticate;

            this.addRoutingRule = addRoutingRule;
            this.updateRoutingRule = updateRoutingRule;
            this.deleteRoutingRule = deleteRoutingRule;
            this.createGroupWithInstitution = createGroupWithInstitution;
            this.getAllGroups = getAllGroups;
        }

        public void Apply(IHttpServer server)
        {
            server.Map("POST", "/api/login", authenticate);

            server.Map("POST", "/api/routing-rules", addRoutingRule);
            server.Map("PUT", "/api/routing-rules/{id}", updateRoutingRule);
            server.Map("DELETE", "/api/routing-rules/{id}", deleteRoutingRule);

            server.Map("POST", "/api/groups", createGroupWithInstitution);
            server.Map("GET", "/api/groups", getAllGroups);
        }
    }
}
