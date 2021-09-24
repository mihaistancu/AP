using AP.Host.Console.Dependencies;

namespace AP.Host.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var store = new Store();
            store.RegisterDependencies();

            store.Get<MessagingOrchestrator>().Start();
            store.Get<MessagingServer>().Start();
            store.Get<ConfigurationServer>().Start();

            System.Console.WriteLine("Press [enter] to stop");
            System.Console.ReadLine();
        }
    }
}
