using AP.Processing.Sync.Handlers.Decryption;

namespace AP.Processing.Sync.Handlers
{
    public class DecryptionHandler : IHandler
    {
        private readonly IDecryptor decryptor;

        public DecryptionHandler(IDecryptor decryptor)
        {
            this.decryptor = decryptor;
        }

        public virtual bool Handle(Message message)
        {
            message.Blob = decryptor.Decrypt(message.Blob);
            return true;
        }
    }
}
