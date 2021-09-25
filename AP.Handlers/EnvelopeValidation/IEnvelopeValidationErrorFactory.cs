using AP.Messaging;

namespace AP.Handlers.EnvelopeValidation
{
    public interface IEnvelopeValidationErrorFactory
    {
        Message Get(string validationMessage);
    }
}
