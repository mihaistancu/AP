namespace AP.Async.Workers.Validation
{
    public class ValidationWorker : Worker
    {
        private readonly IDocumentValidator validator;

        public ValidationWorker(IDocumentValidator validator)
        {
            this.validator = validator;
        }

        public override void Do(Work work)
        {
            System.Console.WriteLine("Validation");

            validator.Validate(work.Message);

            work.Workflow.Done(work);
        }
    }
}
