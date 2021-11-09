using AP.Dependencies;
using AP.Server;
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
            return messaging.Start("http://localhost:9000");
        }

        private static IDisposable StartPortalServer()
        {
            var portal = new OwinHttpServer();
            Context.PortalApi.Apply(portal);
            Context.PortalSpa.Apply(portal);
            return portal.Start("http://localhost:9090");
        }
    }
}
