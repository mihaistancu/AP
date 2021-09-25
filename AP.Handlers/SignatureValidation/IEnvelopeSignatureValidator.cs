using AP.Messaging;

namespace AP.Handlers.SignatureValidation
{
    public interface IEnvelopeSignatureValidator
    {
        ValidationResult Validate(Message message);
    }
}
