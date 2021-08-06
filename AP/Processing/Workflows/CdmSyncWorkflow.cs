using AP.Processing.Workers;

namespace AP.Processing.Sequences
{
    public class CdmSyncWorkflow: LinearWorkflow
    {
        public CdmSyncWorkflow(
            IMessageBroker broker,
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            CdmImportWorker cdmImport,
            CdmSubscriptionExportWorker cdmSubscriptionExport,
            DeliveryWorker delivery,
            ArchivingWorker archiving)
            : base(broker, new WorkerSequence(antimalware, validation, cdmImport, cdmSubscriptionExport, delivery, archiving))
        {
        }
    }
}
