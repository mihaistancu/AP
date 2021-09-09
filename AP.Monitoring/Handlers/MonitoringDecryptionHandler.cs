using AP.Data;
using AP.Processing.Sync.Handlers.Decryption;

namespace AP.Monitoring.Handlers
{
    public class MonitoringDecryptionHandler: DecryptionHandler
    {
        public MonitoringDecryptionHandler(IDecryptor decryptor) : base(decryptor)
        {
        }

        public override bool Handle(Message message)
        {
            System.Console.WriteLine("Decryption");
            return base.Handle(message);
        }
    }
}
