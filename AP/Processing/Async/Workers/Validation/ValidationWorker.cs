using AP.Data;

namespace AP.Processing.Async.Workers.Validation
{
    public class ValidationWorker : IWorker
    {
        private readonly IDocumentValidator validator;

        public ValidationWorker(IDocumentValidator validator)
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
