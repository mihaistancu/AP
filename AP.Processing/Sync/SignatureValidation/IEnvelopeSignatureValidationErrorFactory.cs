namespace AP.Processing.Sync.SignatureValidation
{
    public interface IEnvelopeSignatureValidationErrorFactory
    {
        Message Get(string validationMessage);
    }
}
