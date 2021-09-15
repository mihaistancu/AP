using AP.Processing;
using AP.Processing.Sync.Decryption;

namespace AP.Monitoring.Handlers
{
    public class MonitoringDecryptionHandler: DecryptionHandler
    {
        public MonitoringDecryptionHandler(IDecryptor decryptor) : base(decryptor)
        {
        }

        public override (bool, Message) Handle(Message message)
        {
            System.Console.WriteLine("Decryption");
            return base.Handle(message);
        }
    }
}
