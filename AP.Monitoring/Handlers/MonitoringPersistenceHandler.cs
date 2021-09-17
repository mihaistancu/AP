using AP.Processing;
using AP.Processing.Sync;
using AP.Processing.Sync.Persistence;

namespace AP.Monitoring.Handlers
{
    public class MonitoringPersistenceHandler : PersistenceHandler
    {
        public MonitoringPersistenceHandler(IMessageStorage storage) : base(storage)
        {
        }

        public override void Handle(Message message, IOutput output)
        {
            System.Console.WriteLine("Persistence");
            base.Handle(message, output);
        }
    }
}
