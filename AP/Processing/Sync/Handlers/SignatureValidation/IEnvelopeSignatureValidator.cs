using AP.Data;

namespace AP.Processing.Sync.Handlers.SignatureValidation
{
    public interface IEnvelopeSignatureValidator
    {
        void Validate(Message message);
    }
}
