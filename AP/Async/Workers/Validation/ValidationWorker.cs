using System.Collections.Generic;

namespace AP.Async.Workers.Validation
{
    public class ValidationWorker : IWorker
    {
        private readonly IDocumentValidator validator;

        public ValidationWorker(IDocumentValidator validator)
        {
            this.validator = validator;
        }

        public IEnumerable<Message> Handle(Message message)
        {
            System.Console.WriteLine("Validation");

            validator.Validate(message);

            yield return message;
        }
    }
}
