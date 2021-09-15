using AP.Processing;

namespace AP.Gateways.AP
{
    public interface IEncryptor
    {
        void Encrypt(params Message[] messages);
    }
}
