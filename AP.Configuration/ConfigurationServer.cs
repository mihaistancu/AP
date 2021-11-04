using AP.Configuration.Routing.API;
using AP.IO;
using System;

namespace AP.Configuration
{
    public class ConfigurationServer
    {
        private IWebServer server;
        private GetAllRoutingRulesApi getAllRoutingRules;
        private AddRoutingRuleApi addRoutingRule;
        private UpdateRoutingRuleApi updateRoutingRule;
        private DeleteRoutingRuleApi deleteRoutingRule;
        private GetStaticFile getStaticFile;

        public ConfigurationServer(
            IWebServer server,
            GetAllRoutingRulesApi getAllRoutingRules,
            AddRoutingRuleApi addRoutingRule,
            UpdateRoutingRuleApi updateRoutingRule,
            DeleteRoutingRuleApi deleteRoutingRule, 
            GetStaticFile getStaticFile)
        {
            this.server = server;
            this.getAllRoutingRules = getAllRoutingRules;
            this.addRoutingRule = addRoutingRule;
            this.updateRoutingRule = updateRoutingRule;
            this.deleteRoutingRule = deleteRoutingRule;
            this.getStaticFile = getStaticFile;
        }

        public IDisposable Start()
        {
            server.Map("GET", "/api/routing-rules", getAllRoutingRules);
            server.Map("POST", "/api/routing-rules", addRoutingRule);
            server.Map("PUT", "/api/routing-rules/{id}", updateRoutingRule);
            server.Map("DELETE", "/api/routing-rules/{id}", deleteRoutingRule);
            server.Map("GET", "/*", getStaticFile);

            return server.Start("http://localhost:9090");
        }
    }
}
