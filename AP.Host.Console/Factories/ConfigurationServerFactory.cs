using AP.Configuration.API;
using AP.Configuration.API.Routing;
using AP.Routing;
using AP.Web.Server.Owin;

namespace AP.Host.Console
{
    public class ConfigurationServerFactory
    {
        public ConfigurationServer Get()
        {
            var routingRuleStorage = new RoutingRuleStorage();

            return new ConfigurationServer(
                new OwinWebServer(),
                new GetAllRoutingRulesApi(routingRuleStorage),
                new AddRoutingRuleApi(routingRuleStorage),
                new UpdateRoutingRuleApi(routingRuleStorage),
                new DeleteRoutingRuleApi(routingRuleStorage));
        }
    }
}
