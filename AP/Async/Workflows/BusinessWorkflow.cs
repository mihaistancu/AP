using AP.Async.Workers.Antimalware;
using AP.Async.Workers.Delivery;
using AP.Async.Workers.Validation;

namespace AP.Async.Workflows
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
