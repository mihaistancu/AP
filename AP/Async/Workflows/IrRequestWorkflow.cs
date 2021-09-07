using AP.Async.Workers.Antimalware;
using AP.Async.Workers.Delivery;
using AP.Async.Workers.IR.Export;
using AP.Async.Workers.Validation;

namespace AP.Async.Workflows
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
