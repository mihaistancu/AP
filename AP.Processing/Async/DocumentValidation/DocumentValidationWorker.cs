namespace AP.Processing.Async.DocumentValidation
{
    public class DocumentValidationWorker : IWorker
    {
        private IDocumentValidator validator;
        private IDocumentValidationErrorFactory errorFactory;
        private IMessageStorage storage;
        private IRouter router;

        public DocumentValidationWorker(
            IDocumentValidator validator,
            IDocumentValidationErrorFactory errorFactory,
            IMessageStorage storage,
            IRouter router)
        {
            this.validator = validator;
            this.errorFactory = errorFactory;
            this.storage = storage;
            this.router = router;
        }

        public virtual bool Handle(Message message)
        {
            var result = validator.Validate(message);
            if (!result.IsSuccessful)
            {
                var error = errorFactory.Get(result.Message);
                storage.Save(error);
                router.Route(message.Sender, error);
                return false;
            }
            return true;
        }
    }
}
