using AP.Data;

namespace AP.Processing.Sync.Handlers.SignatureCheck
{
    public class SignatureValidationHandler : IHandler
    {
        private readonly IEnvelopeSignatureValidator validator;

        public SignatureValidationHandler(IEnvelopeSignatureValidator validator)
        {
            this.validator = validator;
        }

        public virtual bool Handle(Message message)
        {
            validator.Validate(message.Blob);
            return true;
        }
    }
}
