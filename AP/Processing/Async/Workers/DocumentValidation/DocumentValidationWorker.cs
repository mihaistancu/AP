using AP.Data;

namespace AP.Processing.Async.Workers.DocumentValidation
{
    public class DocumentValidationWorker : IWorker
    {
        private IDocumentValidator validator;

        public DocumentValidationWorker(IDocumentValidator validator)
        {
            this.validator = validator;
        }

        public virtual Message[] Handle(Message message)
        {
            validator.Validate(message);

            return new[] { message };
        }
    }
}
