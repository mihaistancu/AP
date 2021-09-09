using AP.Data;

namespace AP.Processing.Sync.Handlers.Decryption
{
    public interface IDecryptor
    {
        void Decrypt(Message message);
    }
}
