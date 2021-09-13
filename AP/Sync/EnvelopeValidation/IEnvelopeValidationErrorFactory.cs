namespace AP.Processing.Sync.EnvelopeValidation
{
    public interface IEnvelopeValidationErrorFactory
    {
        Message Get(string validationMessage);
    }
}
