namespace AP.Sync.Handlers.Validation
{
    public interface IEnvelopeValidator
    {
        void Validate(Message message);
    }
}
