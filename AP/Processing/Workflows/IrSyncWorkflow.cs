using AP.Processing.Workers;

namespace AP.Processing.Workflows
{
    public class IrSyncWorkflow : LinearWorkflow
    {
        public IrSyncWorkflow(
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            IrImportWorker irImport,
            IrSubscriptionExportWorker irSubscriptionExport,
            DeliveryWorker delivery,
            ArchivingWorker archiving)
            : base(new WorkerSequence(antimalware, validation, irImport, irSubscriptionExport, delivery, archiving))
        {
        }
    }
}
