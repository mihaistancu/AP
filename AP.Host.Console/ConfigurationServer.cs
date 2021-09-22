using AP.Configuration.Server.Routing;
using AP.Configuration.Server.Settings;
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
            server.Map("GET", "api/routing-rules", store.Get<GetAllRulesApi>());
            server.Map("POST", "api/routing-rules", store.Get<AddRuleApi>());
            server.Map("PUT", "api/routing-rules/{id}", store.Get<UpdateRuleApi>());
            server.Map("DELETE", "api/routing-rules/{id}", store.Get<DeleteRuleApi>());

            server.Map("GET", "api/settings", store.Get<GetAllSettingsApi>());
            server.Map("PUT", "api/settings/{id}", store.Get<UpdateSettingApi>());

            return server.Start("http://localhost:9090");
        }
    }
}
