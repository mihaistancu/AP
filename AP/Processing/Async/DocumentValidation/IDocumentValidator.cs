using AP.Data;

namespace AP.Processing.Async.DocumentValidation
{
    public interface IDocumentValidator
    {
        ValidationResult Validate(Message message);
    }
}
