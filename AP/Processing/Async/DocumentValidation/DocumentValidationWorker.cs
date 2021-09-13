using AP.Data;

namespace AP.Processing.Async.DocumentValidation
{
    public class DocumentValidationWorker : IWorker
    {
        private IDocumentValidator validator;

        public DocumentValidationWorker(IDocumentValidator validator)
        {
            this.validator = validator;
        }

        public virtual void Handle(Message message)
        {
            validator.Validate(message);
        }
    }
}
