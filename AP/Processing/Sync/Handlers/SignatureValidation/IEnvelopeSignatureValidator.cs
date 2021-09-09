namespace AP.Processing.Sync.Handlers.SignatureValidation
{
    public interface IEnvelopeSignatureValidator
    {
        void Validate(byte[] data);
    }
}
