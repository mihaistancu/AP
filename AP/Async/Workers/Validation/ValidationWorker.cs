namespace AP.Async.Workers.Validation
{
    public class ValidationWorker : IWorker
    {
        private readonly IDocumentValidator validator;

        public ValidationWorker(IDocumentValidator validator)
        {
            this.validator = validator;
        }

        public Message[] Handle(Message message)
        {
            System.Console.WriteLine("Validation");

            validator.Validate(message);

            return new[] { message };
        }
    }
}
