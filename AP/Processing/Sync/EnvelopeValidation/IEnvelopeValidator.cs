namespace AP.Processing.Sync.EnvelopeValidation
{
    public interface IEnvelopeValidator
    {
        ValidationResult Validate(Message message);
    }
}
