using AP.Handlers.SignatureValidation;
using AP.Messages;

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
