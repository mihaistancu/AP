using AP.Configuration;
using AP.Configuration.Routing.API;
using AP.Https;
using AP.Routing;

namespace AP.Dependencies.Factories
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
                new DeleteRoutingRuleApi(routingRuleStorage),
                new GetStaticFile("./dist"));
        }
    }
}
