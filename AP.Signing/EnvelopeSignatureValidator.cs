using AP.Processing;
using AP.Processing.Sync.SignatureValidation;

namespace AP.Signing
{
    public class EnvelopeSignatureValidator : IEnvelopeSignatureValidator
    {
        public ValidationResult Validate(Message message)
        {
            return new ValidationResult
            {
                IsSuccessful = true
            };
        }
    }
}
