using AP.Messaging;

namespace AP.Handlers.SignatureValidation
{
    public interface IEnvelopeSignatureValidationErrorFactory
    {
        Message Get(string validationMessage);
    }
}
