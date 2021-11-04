using AP.Configuration;
using AP.Configuration.Routing.API;
using AP.Https;
using AP.Portal;
using AP.Routing;

namespace AP.Dependencies.Factories
{
    public class PortalServerFactory
    {
        public static PortalServer Get()
        {
            var routingRuleStorage = new RoutingRuleStorage();

            var routes = new ApiRoutes(
                new GetAllRoutingRulesApi(routingRuleStorage),
                new AddRoutingRuleApi(routingRuleStorage),
                new UpdateRoutingRuleApi(routingRuleStorage),
                new DeleteRoutingRuleApi(routingRuleStorage));

            var server = new OwinWebServer();

            return new PortalServer(server, routes);
        }
    }
}
