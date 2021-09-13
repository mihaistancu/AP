using AP.Data;
using AP.Processing.Sync;
using AP.Processing.Sync.Decryption;

namespace AP.Monitoring.Handlers
{
    public class MonitoringDecryptionHandler: DecryptionHandler
    {
        public MonitoringDecryptionHandler(IDecryptor decryptor) : base(decryptor)
        {
        }

        public override bool Handle(Message message, IOutput output)
        {
            System.Console.WriteLine("Decryption");
            return base.Handle(message, output);
        }
    }
}
