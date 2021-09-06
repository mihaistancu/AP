using AP.Processing.Workers.Antimalware;
using AP.Processing.Workers.Delivery;
using AP.Processing.Workers.IR;
using AP.Processing.Workers.Validation;

namespace AP.Processing.Workflows
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
