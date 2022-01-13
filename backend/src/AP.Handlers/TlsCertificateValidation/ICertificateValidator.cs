using AP.Messages;

namespace AP.Handlers.TlsCertificateValidation
{
    public interface ICertificateValidator
    {
        ValidationResult Validate(Certificate certificate);
    }
}
