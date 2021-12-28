using AP.Dependencies;
using System;

namespace AP.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Context.Build();

            using (StartTrace())
            using (StartOrchestrator())
            using (StartMessagingServer())
            using (StartPortalServer())
            {
                Console.WriteLine("Press [enter] to stop");
                Console.ReadLine();
            }
        }

        public static IDisposable StartTrace()
        {
            return Context.Trace.Start();
        }

        private static IDisposable StartOrchestrator()
        {
            return Context.Orchestrator.Start();
        }

        private static IDisposable StartMessagingServer()
        {
            var messaging = Context.ServerFactory.Create();
            Context.MessageEndpoints.Apply(messaging);
            return messaging.Start("http://localhost:9000");
        }

        private static IDisposable StartPortalServer()
        {
            var portal = Context.ServerFactory.Create();
            Context.PortalApi.Apply(portal);
            Context.PortalSpa.Apply(portal);
            return portal.Start("http://localhost:9090");
        }
    }
}
