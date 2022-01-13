using AP.Messages;

namespace AP.Handlers.EnvelopeValidation
{
    public interface IEnvelopeValidator
    {
        ValidationResult Validate(Message message);
    }
}
