using AP.Async.Workers.Antimalware;
using AP.Async.Workers.Delivery;
using AP.Async.Workers.IR;
using AP.Async.Workers.IR.Export;
using AP.Async.Workers.Validation;

namespace AP.Async.Workflows
{
    public class IrSyncWorkflow : LinearWorkflow
    {
        public IrSyncWorkflow(
            IMessageBroker broker,
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            IrImportWorker irImport,
            IrSubscriptionExportWorker irSubscriptionExport,
            DeliveryWorker delivery)
            : base(broker, antimalware, validation, irImport, irSubscriptionExport, delivery)
        {
        }
    }
}
