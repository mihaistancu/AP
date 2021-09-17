﻿using AP.Processing;
using AP.Processing.Sync;
using AP.Processing.Sync.Decryption;

namespace AP.Monitoring.Handlers
{
    public class MonitoringDecryptionHandler: DecryptionHandler
    {
        public MonitoringDecryptionHandler(IDecryptor decryptor) : base(decryptor)
        {
        }

        public override void Handle(Message message, IOutput output)
        {
            System.Console.WriteLine("Decryption");
            base.Handle(message, output);
        }
    }
}
