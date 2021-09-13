using AP.Data;

namespace AP.Processing.Sync.SignatureValidation
{
    public class SignatureValidationHandler : IHandler
    {
        private IEnvelopeSignatureValidator validator;

        public SignatureValidationHandler(IEnvelopeSignatureValidator validator)
        {
            this.validator = validator;
        }

        public virtual bool Handle(Message message, IOutput output)
        {
            validator.Validate(message);
            return true;
        }
    }
}
