using AP.Processing.Workers;

namespace AP.Processing.Workflows
{
    public class CdmSyncWorkflow : LinearWorkflow
    {
        public CdmSyncWorkflow(
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            CdmImportWorker cdmImport,
            CdmSubscriptionExportWorker cdmSubscriptionExport,
            DeliveryWorker delivery,
            ArchivingWorker archiving)
            : base(new WorkerSequence(antimalware, validation, cdmImport, cdmSubscriptionExport, delivery, archiving))
        {
        }
    }
}
