namespace AP.Processing.Sync.Handlers.Validation
{
    public class ValidationHandler : IHandler
    {
        private readonly IEnvelopeValidator validator;

        public ValidationHandler(IEnvelopeValidator validator)
        {
            this.validator = validator;
        }

        public bool Handle(Message message)
        {
            System.Console.WriteLine("Validation");

            validator.Validate(message);

            return true;
        }
    }
}
