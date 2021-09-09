using AP.Data;

namespace AP.Processing.Sync.Handlers.TlsCertificateValidation
{
    public interface ICertificateValidator
    {
        void Validate(Certificate certificate);
    }
}
