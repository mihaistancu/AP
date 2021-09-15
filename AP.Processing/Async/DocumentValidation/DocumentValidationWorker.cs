namespace AP.Processing.Async.DocumentValidation
{
    public class DocumentValidationWorker<T> : IWorker where T: IGateway
    {
        private IDocumentValidator validator;
        private IDocumentValidationErrorFactory errorFactory;
        private IMessageStorage storage;
        private T gateway;

        public DocumentValidationWorker(
            IDocumentValidator validator,
            IDocumentValidationErrorFactory errorFactory,
            IMessageStorage storage,
            T gateway)
        {
            this.validator = validator;
            this.errorFactory = errorFactory;
            this.storage = storage;
            this.gateway = gateway;
        }

        public virtual bool Handle(Message message)
        {
            var result = validator.Validate(message);
            if (!result.IsSuccessful)
            {
                var error = errorFactory.Get(result.Message);
                storage.Save(error);
                gateway.Deliver(error);
                return false;
            }
            return true;
        }
    }
}
