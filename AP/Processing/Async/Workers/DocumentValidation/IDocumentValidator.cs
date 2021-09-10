using AP.Data;

namespace AP.Processing.Async.Workers.DocumentValidation
{
    public interface IDocumentValidator
    {
        void Validate(Message message);
    }
}
