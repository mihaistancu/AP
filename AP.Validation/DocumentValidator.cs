using AP.Messaging;
using AP.Workers.DocumentValidation;

namespace AP.Validation
{
    public class DocumentValidator : IDocumentValidator
    {
        ValidationResult IDocumentValidator.Validate(Message message)
        {
            return new ValidationResult 
            { 
                IsSuccessful = true 
            };
        }
    }
}
