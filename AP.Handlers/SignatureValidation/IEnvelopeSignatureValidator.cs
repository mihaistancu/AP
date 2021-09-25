using AP.Messages;

namespace AP.Handlers.SignatureValidation
{
    public interface IEnvelopeSignatureValidator
    {
        ValidationResult Validate(Message message);
    }
}
