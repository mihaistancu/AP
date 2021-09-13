using AP.Data;

namespace AP.Processing.Sync.SignatureValidation
{
    public interface IEnvelopeSignatureValidator
    {
        void Validate(Message message);
    }
}
