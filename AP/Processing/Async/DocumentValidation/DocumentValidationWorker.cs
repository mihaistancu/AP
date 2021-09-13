using AP.Data;

namespace AP.Processing.Async.DocumentValidation
{
    public class DocumentValidationWorker : IWorker
    {
        private IDocumentValidator validator;
        private IDocumentValidationErrorFactory errorFactory;
        private IMessageStorage storage;
        private Orchestrator orchestrator;

        public DocumentValidationWorker(
            IDocumentValidator validator,
            IDocumentValidationErrorFactory errorFactory,
            IMessageStorage storage,
            Orchestrator orchestrator)
        {
            this.validator = validator;
            this.errorFactory = errorFactory;
            this.storage = storage;
            this.orchestrator = orchestrator;
        }

        public virtual bool Handle(Message message)
        {
            var result = validator.Validate(message);
            if (!result.IsSuccessful)
            {
                var error = errorFactory.Get(result.Message);
                storage.Save(error);
                orchestrator.ProcessAsync(error);
                return false;
            }
            return true;
        }
    }
}
