using AP.Messaging;

namespace AP.Handlers.TlsCertificateValidation
{
    public interface ICertificateValidator
    {
        ValidationResult Validate(Certificate certificate);
    }
}
