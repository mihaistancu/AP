using AP.Processing.Workflows;

namespace AP.Processing
{
    public class AsyncProcessor : IAsyncProcessor
    {
        private readonly WorkflowFactory factory;
        private readonly ExceptionHandler exceptionHandler;

        public AsyncProcessor(WorkflowFactory factory, ExceptionHandler exceptionHandler)
        {
            this.factory = factory;
            this.exceptionHandler = exceptionHandler;
        }

        public void Process(Message message)
        {
            var workflow = factory.Get(message.SedType);

            var work = new Work
            {
                Message = message,
                Workflow = workflow,
                ExceptionHandler = exceptionHandler
            };

            workflow.Start(work);
        }
    }
}
