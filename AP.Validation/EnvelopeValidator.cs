using AP.Handlers.EnvelopeValidation;
using AP.Messaging;

namespace AP.Validation
{
    public class EnvelopeValidator : IEnvelopeValidator
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
