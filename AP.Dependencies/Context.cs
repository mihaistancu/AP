﻿using AP.Broker;
using AP.Client;
using AP.Configuration.Routing.API;
using AP.Dependencies.Factories;
using AP.Endpoints;
using AP.Monitoring;
using AP.Orchestration;
using AP.Queue;
using AP.Routing;
using AP.Storage;
using AP.Web.Authentication;
using AP.Web.Authorization;
using AP.Web.Files;
using AP.Web.Identity;
using AP.Web.Routes;

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
        public static ApiRoutes PortalApi { get; set; }
        public static LoginRoutes Login { get; set; }
        public static SpaRoutes PortalSpa { get; set; }

        public static void Build()
        {
            MessageStorage = new MessageStorage();
            MessageClient = new MonitoredMessageClient();
            MessageQueue = new MonitoredMessageQueue();
            ClaimsStorage = new ClaimsStorage();
            Orchestrator = BuildOrchestrator();
            Authorizer = BuildAuthorizer();
            MessageEndpoints = BuildMessageEndpoints();
            PortalApi = BuildPortalApi();
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

        private static ApiRoutes BuildPortalApi()
        {
            var routingRuleStorage = new RoutingRuleStorage();

            return new ApiRoutes(
                Authorizer,
                new GetAllRoutingRulesApi(routingRuleStorage),
                new AddRoutingRuleApi(routingRuleStorage),
                new UpdateRoutingRuleApi(routingRuleStorage),
                new DeleteRoutingRuleApi(routingRuleStorage));
        }

        private static LoginRoutes BuildLogin()
        {
            var authenticator = new Authenticator(new ActiveDirectory(), ClaimsStorage);
            return new LoginRoutes(new FileServer(), authenticator);
        }

        private static SpaRoutes BuildPortalSpa()
        {
            return new SpaRoutes(new FileServer(), Authorizer);
        }
    }
}
