using AP.Processing.Async.Workers.Antimalware;
using AP.Processing.Async.Workers.Delivery;
using AP.Processing.Async.Workers.Validation;

namespace AP.Processing.Async.Workflows
{
    public class BusinessWorkflow : Workflow
    {
        public BusinessWorkflow(
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            DeliveryWorker delivery)
            : base(antimalware, validation, delivery)
        {
        }
    }
}
