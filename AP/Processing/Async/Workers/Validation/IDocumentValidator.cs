namespace AP.Processing.Async.Workers.Validation
{
    public interface IDocumentValidator
    {
        void Validate(Message message);
    }
}
