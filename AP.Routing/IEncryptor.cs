using AP.Processing;

namespace AP.Routing
{
    public interface IEncryptor
    {
        void Encrypt(params Message[] messages);
    }
}
