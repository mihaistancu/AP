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

        public virtual bool Handle(Message message, IOutput output)
        {
            var result = validator.Validate(message);
            if (!result.IsSuccessful)
            {
                var error = errorFactory.Get(result.Message);
                output.Buffer(error);
                return false;
            }
            return true;
        }
    }
}
