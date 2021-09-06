namespace AP.Async.Workers.Validation
{
    public interface IDocumentValidator
    {
        void Validate(Message message);
    }
}
