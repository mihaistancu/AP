using AP.Messaging;

namespace AP.Workers.DocumentValidation
{
    public interface IDocumentValidationErrorFactory
    {
        Message Get(string validationMessage);
    }
}
