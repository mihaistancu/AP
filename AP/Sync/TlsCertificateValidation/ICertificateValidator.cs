namespace AP.Processing.Sync.TlsCertificateValidation
{
    public interface ICertificateValidator
    {
        ValidationResult Validate(Certificate certificate);
    }
}
