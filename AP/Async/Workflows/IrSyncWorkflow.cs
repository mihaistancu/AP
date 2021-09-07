using AP.Async.Workers.Antimalware;
using AP.Async.Workers.Delivery;
using AP.Async.Workers.IR;
using AP.Async.Workers.IR.Export;
using AP.Async.Workers.Validation;

namespace AP.Async.Workflows
{
    public class IrSyncWorkflow : Workflow
    {
        public IrSyncWorkflow(
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            IrImportWorker irImport,
            IrSubscriptionExportWorker irSubscriptionExport,
            DeliveryWorker delivery)
            : base(antimalware, validation, irImport, irSubscriptionExport, delivery)
        {
        }
    }
}
