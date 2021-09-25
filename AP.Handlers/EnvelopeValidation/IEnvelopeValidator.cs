using AP.Messaging;

namespace AP.Handlers.EnvelopeValidation
{
    public interface IEnvelopeValidator
    {
        ValidationResult Validate(Message message);
    }
}
