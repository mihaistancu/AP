using AP.Configuration.API;
using AP.Configuration.Service.Routing.API;
using AP.Routing;
using AP.Web.Server.Owin;

namespace AP.Host.Console
{
    public class ConfigurationServerFactory
    {
        public static ConfigurationServer Get()
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
