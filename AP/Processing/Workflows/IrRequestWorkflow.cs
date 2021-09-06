using AP.Processing.Workers.Antimalware;
using AP.Processing.Workers.Delivery;
using AP.Processing.Workers.IR;
using AP.Processing.Workers.Validation;

namespace AP.Processing.Workflows
{
    public class IrRequestWorkflow : LinearWorkflow
    {
        public IrRequestWorkflow(
            IMessageBroker broker,
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            IrRequestExportWorker irRequestExport,
            DeliveryWorker delivery)
            : base(broker, antimalware, validation, irRequestExport, delivery)
        {
        }
    }
}
