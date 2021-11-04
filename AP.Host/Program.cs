using AP.Dependencies;

namespace AP.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Context.Build();

            using (Context.Orchestrator.Start())
            using (Context.MessageServer.Start())
            using (Context.PortalServer.Start())
            {
                System.Console.WriteLine("Press [enter] to stop");
                System.Console.ReadLine();
            }
        }
    }
}
