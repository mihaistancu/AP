using AP.Data;

namespace AP.Processing.Sync.Handlers.Auth
{
    public interface ICertificateValidator
    {
        void Validate(Certificate certificate);
    }
}
