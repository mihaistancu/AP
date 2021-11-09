﻿using AP.Http;

namespace AP.Web.Routes
{
    public class ApiRoutes
    {
        private HttpHandler authenticate;
        private HttpHandler getAllRoutingRules;
        private HttpHandler addRoutingRule;
        private HttpHandler updateRoutingRule;
        private HttpHandler deleteRoutingRule;

        public ApiRoutes(
            HttpHandler authenticate,
            HttpHandler getAllRoutingRules,
            HttpHandler addRoutingRule,
            HttpHandler updateRoutingRule,
            HttpHandler deleteRoutingRule)
        {
            this.authenticate = authenticate;
            this.getAllRoutingRules = getAllRoutingRules;
            this.addRoutingRule = addRoutingRule;
            this.updateRoutingRule = updateRoutingRule;
            this.deleteRoutingRule = deleteRoutingRule;
        }

        public void Apply(IHttpServer server)
        {
            server.Map("POST", "/api/login", authenticate);

            server.Map("GET", "/api/routing-rules", getAllRoutingRules);
            server.Map("POST", "/api/routing-rules", addRoutingRule);
            server.Map("PUT", "/api/routing-rules/{id}", updateRoutingRule);
            server.Map("DELETE", "/api/routing-rules/{id}", deleteRoutingRule);
        }
    }
}
