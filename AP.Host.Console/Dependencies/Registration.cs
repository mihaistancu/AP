using Unity;
using AP.Processing.Async;
using AP.Routing;
using Unity.RegistrationByConvention;
using AP.Messaging.Client;
using AP.Monitoring;
using AP.Messaging.Queue;

namespace AP.Host.Console
{
    public class Registration
    {
        public static void Setup(UnityContainer container)
        {
            container.RegisterTypes(
                AllClasses.FromAssembliesInBasePath(),
                WithMappings.FromMatchingInterface,
                WithName.Default);

            container.RegisterType<MessageClient, MonitoredMessageClient>();
            container.RegisterType<MessageQueue, MonitoredMessageQueue>();

            container.RegisterType<WorkerMap>(TypeLifetime.Singleton);
            container.RegisterType<RoutingRuleStorage>(TypeLifetime.Singleton);
            container.RegisterType<Orchestrator>(TypeLifetime.Singleton);
        }
    }
}
