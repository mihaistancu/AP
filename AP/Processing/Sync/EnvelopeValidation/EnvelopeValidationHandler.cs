using AP.Data;

namespace AP.Processing.Sync.EnvelopeValidation
{
    public class EnvelopeValidationHandler : IHandler
    {
        private IEnvelopeValidator validator;

        public EnvelopeValidationHandler(IEnvelopeValidator validator)
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
