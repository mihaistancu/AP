using AP.Processing;
using AP.Processing.Sync.EnvelopeValidation;

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
