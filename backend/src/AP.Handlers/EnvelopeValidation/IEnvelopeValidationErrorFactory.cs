using AP.Messages;

namespace AP.Handlers.EnvelopeValidation
{
    public interface IEnvelopeValidationErrorFactory
    {
        Message Get(string validationMessage);
    }
}
