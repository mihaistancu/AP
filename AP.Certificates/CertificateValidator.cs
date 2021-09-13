using AP.Processing;
using AP.Processing.Sync.TlsCertificateValidation;

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
