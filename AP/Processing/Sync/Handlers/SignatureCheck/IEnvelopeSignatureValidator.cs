namespace AP.Processing.Sync.Handlers.SignatureCheck
{
    public interface IEnvelopeSignatureValidator
    {
        void Validate(byte[] data);
    }
}
