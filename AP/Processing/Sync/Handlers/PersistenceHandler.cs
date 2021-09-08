namespace AP.Processing.Sync.Handlers
{
    public class PersistenceHandler : IHandler
    {
        public bool Handle(Message message)
        {
            System.Console.WriteLine("Persistence");
            return true;
        }
    }
}
