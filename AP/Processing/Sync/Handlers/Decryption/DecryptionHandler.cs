using AP.Data;

namespace AP.Processing.Sync.Handlers.Decryption
{
    public class DecryptionHandler : IHandler
    {
        private IDecryptor decryptor;

        public DecryptionHandler(IDecryptor decryptor)
        {
            this.decryptor = decryptor;
        }

        public virtual bool Handle(Message message)
        {
            decryptor.Decrypt(message);
            return true;
        }
    }
}
