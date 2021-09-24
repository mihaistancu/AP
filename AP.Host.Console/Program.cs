namespace AP.Host.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();
            context.SetMonitoring(true);
            context.RegisterDependencies();
            
            context.Orchestrator.Start();
            context.MessageServer.Start();
            context.ConfigurationServer.Start();

            System.Console.WriteLine("Press [enter] to stop");
            System.Console.ReadLine();
        }
    }
}
