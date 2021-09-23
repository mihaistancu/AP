using Unity;

namespace AP.Host.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            Registration.Setup(container);

            container.Resolve<MessagingOrchestrator>().Start();
            container.Resolve<MessagingServer>().Start();
            container.Resolve<ConfigurationServer>().Start();

            System.Console.WriteLine("Press [enter] to stop");
            System.Console.ReadLine();
        }
    }
}
