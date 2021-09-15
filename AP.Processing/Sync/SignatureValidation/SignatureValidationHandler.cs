namespace AP.Processing.Sync.SignatureValidation
{
    public class SignatureValidationHandler : IHandler
    {
        private IEnvelopeSignatureValidator validator;
        private IEnvelopeSignatureValidationErrorFactory errorFactory;

        public SignatureValidationHandler(
            IEnvelopeSignatureValidator validator,
            IEnvelopeSignatureValidationErrorFactory errorFactory)
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
