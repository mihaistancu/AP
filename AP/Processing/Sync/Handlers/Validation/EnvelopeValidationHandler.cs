using AP.Data;

namespace AP.Processing.Sync.Handlers.Validation
{
    public class EnvelopeValidationHandler : IHandler
    {
        private readonly IEnvelopeValidator validator;

        public EnvelopeValidationHandler(IEnvelopeValidator validator)
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
