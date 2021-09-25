using AP.Handlers.SignatureValidation;
using AP.Messaging;

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
