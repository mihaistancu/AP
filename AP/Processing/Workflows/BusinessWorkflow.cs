using AP.Processing.Workers.Antimalware;
using AP.Processing.Workers.Delivery;
using AP.Processing.Workers.Validation;

namespace AP.Processing.Workflows
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
