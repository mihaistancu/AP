namespace AP.Host.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new Host();
            host.RegisterDependencies();

            using (host.Orchestrator.Start())
            using (host.MessageServer.Start())
            using (host.ConfigurationServer.Start())
            {
                System.Console.WriteLine("Press [enter] to stop");
                System.Console.ReadLine();
            }
        }
    }
}
