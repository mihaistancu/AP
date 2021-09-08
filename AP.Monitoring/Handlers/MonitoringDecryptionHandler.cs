using AP.Processing.Sync.Handlers;

namespace AP.Monitoring.Handlers
{
    public class MonitoringDecryptionHandler: DecryptionHandler
    {
        public override bool Handle(Message message)
        {
            System.Console.WriteLine("Decryption");
            return base.Handle(message);
        }
    }
}
