namespace AP.Host.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new Host();
            host.RegisterDependencies();
            
            host.Orchestrator.Start();
            host.MessageServer.Start();
            host.ConfigurationServer.Start();

            System.Console.WriteLine("Press [enter] to stop");
            System.Console.ReadLine();
        }
    }
}
