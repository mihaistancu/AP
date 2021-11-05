using AP.Dependencies;
using AP.Server;
using AP.Web;
using System;

namespace AP.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Context.Build();

            using (StartOrchestrator())
            using (StartMessagingServer())
            using (StartPortalServer())
            {
                Console.WriteLine("Press [enter] to stop");
                Console.ReadLine();
            }
        }

        private static IDisposable StartOrchestrator()
        {
            return Context.Orchestrator.Start();
        }

        private static IDisposable StartMessagingServer()
        {
            var messaging = new OwinHttpServer();
            Context.MessageEndpoints.Apply(messaging);
            return messaging.Start(Config.MessagingServerBaseUrl);
        }

        private static IDisposable StartPortalServer()
        {
            var portal = new OwinHttpServer();
            Context.ConfigurationApi.Apply(portal);
            var spa = new StaticFileRoutes(Config.PortalStaticFilesPath);
            spa.Apply(portal);
            return portal.Start(Config.PortalServerBaseUrl);
        }   
    }
}
