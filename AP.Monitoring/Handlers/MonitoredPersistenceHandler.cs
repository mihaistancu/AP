using AP.Processing;
using AP.Processing.Sync;
using AP.Processing.Sync.Persistence;

namespace AP.Monitoring.Handlers
{
    public class MonitoredPersistenceHandler : PersistenceHandler
    {
        public MonitoredPersistenceHandler(IMessageStorage storage) : base(storage)
        {
        }

        public override void Handle(Message message, IOutput output)
        {
            System.Console.WriteLine("Persistence");
            base.Handle(message, output);
        }
    }
}
