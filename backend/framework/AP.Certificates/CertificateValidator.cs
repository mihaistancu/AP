using AP.Handlers.TlsCertificateValidation;
using AP.Messages;

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
