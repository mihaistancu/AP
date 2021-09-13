using AP.Data;
using AP.Processing.Async.DocumentValidation;

namespace AP.Validation
{
    public class DocumentValidator : IDocumentValidator
    {
        ValidationResult IDocumentValidator.Validate(Message message)
        {
            return new ValidationResult { IsSuccessful = true };
        }
    }
}
