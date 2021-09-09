using AP.Data;

namespace AP.Processing.Sync.Handlers.SignatureValidation
{
    public class SignatureValidationHandler : IHandler
    {
        private IEnvelopeSignatureValidator validator;

        public SignatureValidationHandler(IEnvelopeSignatureValidator validator)
        {
            this.validator = validator;
        }

        public virtual bool Handle(Message message)
        {
            validator.Validate(message);
            return true;
        }
    }
}
