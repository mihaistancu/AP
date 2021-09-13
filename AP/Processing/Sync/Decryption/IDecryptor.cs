using AP.Data;

namespace AP.Processing.Sync.Decryption
{
    public interface IDecryptor
    {
        void Decrypt(Message message);
    }
}
