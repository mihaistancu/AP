namespace AP.Processing.Sync.EnvelopeValidation
{
    public class EnvelopeValidationHandler : IHandler
    {
        private IEnvelopeValidator validator;
        private IEnvelopeValidationErrorFactory errorFactory;

        public EnvelopeValidationHandler(
            IEnvelopeValidator validator,
            IEnvelopeValidationErrorFactory errorFactory)
        {
            this.validator = validator;
            this.errorFactory = errorFactory;
        }

        public virtual (bool, Message) Handle(Message message)
        {
            var result = validator.Validate(message);
            if (!result.IsSuccessful)
            {
                var error = errorFactory.Get(result.Message);
                return (false, error);
            }
            return (true, null);
        }
    }
}
