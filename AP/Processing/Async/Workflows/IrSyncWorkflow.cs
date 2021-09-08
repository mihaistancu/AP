using AP.Processing.Async.Workers.Antimalware;
using AP.Processing.Async.Workers.Delivery;
using AP.Processing.Async.Workers.IR.Export;
using AP.Processing.Async.Workers.IR.Import;
using AP.Processing.Async.Workers.Validation;

namespace AP.Processing.Async.Workflows
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
