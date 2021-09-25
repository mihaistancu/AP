namespace AP.Host.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Context.Build();

            using (Context.Orchestrator.Start())
            using (Context.MessageServer.Start())
            using (Context.ConfigurationServer.Start())
            {
                System.Console.WriteLine("Press [enter] to stop");
                System.Console.ReadLine();
            }
        }
    }
}
