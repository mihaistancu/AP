using AP.Handlers.TlsCertificateValidation;
using AP.Messaging;

namespace AP.Certificates
{
    public class CertificateValidator : ICertificateValidator
    {
        public ValidationResult Validate(Certificate certificate)
        {
            return new ValidationResult
            {
                IsSuccessful = true
            };
        }
    }
}
