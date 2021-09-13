namespace AP.Processing.Sync.SignatureValidation
{
    public interface IEnvelopeSignatureValidator
    {
        ValidationResult Validate(Message message);
    }
}
