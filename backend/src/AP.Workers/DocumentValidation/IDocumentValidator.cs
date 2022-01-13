using AP.Messages;

namespace AP.Workers.DocumentValidation
{
    public interface IDocumentValidator
    {
        ValidationResult Validate(Message message);
    }
}
