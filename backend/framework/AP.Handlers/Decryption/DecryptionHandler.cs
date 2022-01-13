﻿using AP.Messages;

namespace AP.Handlers.Decryption
{
    public class DecryptionHandler : IHandler
    {
        private IDecryptor decryptor;

        public DecryptionHandler(IDecryptor decryptor)
        {
            this.decryptor = decryptor;
        }

        public virtual void Handle(Message message, IOutput output)
        {
            decryptor.Decrypt(message);
        }
    }
}
