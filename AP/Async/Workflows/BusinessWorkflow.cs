using AP.Async.Workers.Antimalware;
using AP.Async.Workers.Delivery;
using AP.Async.Workers.Validation;

namespace AP.Async.Workflows
{
    public class BusinessWorkflow : LinearWorkflow
    {
        public BusinessWorkflow(
            IMessageBroker broker,
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            DeliveryWorker delivery)
            : base(broker, antimalware, validation, delivery)
        {
        }
    }
}
