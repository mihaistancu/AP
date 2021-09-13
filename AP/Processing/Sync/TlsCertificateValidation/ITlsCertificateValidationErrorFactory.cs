namespace AP.Processing.Sync.TlsCertificateValidation
{
    public interface ITlsCertificateValidationErrorFactory
    {
        Message Get(string validationMessage);
    }
}
