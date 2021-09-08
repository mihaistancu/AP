namespace AP.Processing.Sync.Handlers.Validation
{
    public class ValidationHandler : IHandler
    {
        private readonly IEnvelopeValidator validator;

        public ValidationHandler(IEnvelopeValidator validator)
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
