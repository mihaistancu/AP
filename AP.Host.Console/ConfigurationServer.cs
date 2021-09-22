using AP.Configuration.API.Routing;
using AP.Web.Server.Owin;
using System;

namespace AP.Host.Console
{
    public class ConfigurationServer
    {
        private WebServer server;
        private Store store;

        public ConfigurationServer(WebServer server, Store store)
        {
            this.server = server;
            this.store = store;
        }

        public IDisposable Start()
        {
            server.Map("GET", "/api/routing-rules", store.Get<GetAllRoutingRulesApi>());
            server.Map("POST", "/api/routing-rules", store.Get<AddRoutingRuleApi>());
            server.Map("PUT", "/api/routing-rules/{id}", store.Get<UpdateRoutingRuleApi>());
            server.Map("DELETE", "/api/routing-rules/{id}", store.Get<DeleteRoutingRuleApi>());

            return server.Start("http://localhost:9090");
        }
    }
}
