using AP.Data;

namespace AP.Processing.Async.DocumentValidation
{
    public interface IDocumentValidator
    {
        void Validate(Message message);
    }
}
