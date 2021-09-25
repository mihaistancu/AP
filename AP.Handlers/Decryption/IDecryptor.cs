using AP.Messaging;

namespace AP.Handlers.Decryption
{
    public interface IDecryptor
    {
        void Decrypt(Message message);
    }
}
