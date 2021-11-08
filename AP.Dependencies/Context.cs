using AP.Authorization;
using AP.Broker;
using AP.Client;
using AP.Configuration;
using AP.Configuration.Routing.API;
using AP.Dependencies.Factories;
using AP.Endpoints;
using AP.Identity;
using AP.Login;
using AP.Monitoring;
using AP.Orchestration;
using AP.Queue;
using AP.Routing;
using AP.Storage;
using AP.Web;

namespace AP.Dependencies
{
    public class Context
    {
        public static MessageStorage MessageStorage { get; set; }
        public static Orchestrator Orchestrator { get; set; }
        public static MessageClient MessageClient { get; set; }
        public static MessageQueue MessageQueue { get; set; }
        public static ClaimsStorage ClaimsStorage { get; set; }
        public static Authorizer Authorizer { get; set; }
        public static MessageEndpointRoutes MessageEndpoints { get; set; }
        public static ConfigurationApiRoutes ConfigurationApi { get; set; }
        public static LoginRoutes Login { get; set; }
        public static PortalSpaRoutes PortalSpa { get; set; }

        public static void Build()
        {
            MessageStorage = new MessageStorage();
            MessageClient = new MonitoredMessageClient();
            MessageQueue = new MonitoredMessageQueue();
            ClaimsStorage = new ClaimsStorage();
            Orchestrator = BuildOrchestrator();
            Authorizer = BuildAuthorizer();
            MessageEndpoints = BuildMessageEndpoints();
            ConfigurationApi = BuildConfigurationApi();
            Login = BuildLogin();
            PortalSpa = BuildPortalSpa();
        }

        private static Authorizer BuildAuthorizer()
        {
            return new Authorizer(ClaimsStorage);
        }

        private static Orchestrator BuildOrchestrator()
        {
            return new Orchestrator(
                new OrchestratorConfig(),
                MessageStorage,
                new MessageBroker(new RabbitMqBroker()),
                new WorkerFactory());
        }

        private static MessageEndpointRoutes BuildMessageEndpoints()
        {
            return new MessageEndpointRoutes(new HandlerFactory());
        }

        private static ConfigurationApiRoutes BuildConfigurationApi()
        {
            var routingRuleStorage = new RoutingRuleStorage();

            return new ConfigurationApiRoutes(
                Authorizer,
                new GetAllRoutingRulesApi(routingRuleStorage),
                new AddRoutingRuleApi(routingRuleStorage),
                new UpdateRoutingRuleApi(routingRuleStorage),
                new DeleteRoutingRuleApi(routingRuleStorage));
        }

        private static LoginRoutes BuildLogin()
        {
            return new LoginRoutes(new EmbeddedResourceServer(), ClaimsStorage);
        }

        private static PortalSpaRoutes BuildPortalSpa()
        {
            return new PortalSpaRoutes(new FileServer(), Authorizer);
        }
    }
}
