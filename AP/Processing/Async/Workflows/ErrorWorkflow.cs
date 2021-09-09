using AP.Processing.Async.Workers.Delivery;

namespace AP.Processing.Async.Workflows
{
    public class ErrorWorkflow : Workflow
    {
        public ErrorWorkflow(DeliveryWorker delivery) : base(delivery)
        {
        }
    }
}
