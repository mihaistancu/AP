using AP.Data;

namespace AP.Processing.Async.DocumentValidation
{
    public interface IDocumentValidationErrorFactory
    {
        Message Get(string validationMessage);
    }
}
