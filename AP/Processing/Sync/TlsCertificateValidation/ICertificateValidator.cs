using AP.Data;

namespace AP.Processing.Sync.TlsCertificateValidation
{
    public interface ICertificateValidator
    {
        void Validate(Certificate certificate);
    }
}
