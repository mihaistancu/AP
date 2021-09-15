namespace AP.Processing.Sync.Decryption
{
    public class DecryptionHandler : IHandler
    {
        private IDecryptor decryptor;

        public DecryptionHandler(IDecryptor decryptor)
        {
            this.decryptor = decryptor;
        }

        public virtual (bool, Message) Handle(Message message)
        {
            decryptor.Decrypt(message);
            return (true, null);
        }
    }
}
