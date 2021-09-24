namespace AP.Host.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var store = new Store();
            store.RegisterDependencies();
            
            store.GetOrchestrator().Start();
            store.GetMessageServer().Start();
            store.GetConfigurationServer().Start();

            System.Console.WriteLine("Press [enter] to stop");
            System.Console.ReadLine();
        }
    }
}
