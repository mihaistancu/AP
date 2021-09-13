namespace AP.Processing.Async.DocumentValidation
{
    public interface IDocumentValidationErrorFactory
    {
        Message Get(string validationMessage);
    }
}
