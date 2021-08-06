using AP.Processing.Workers;

namespace AP.Processing.Sequences
{
    public class CdmSyncSequence: Sequence
    {
        public CdmSyncSequence(
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            CdmImportWorker cdmImport,
            CdmSubscriptionExportWorker cdmSubscriptionExport,
            DeliveryWorker delivery,
            ArchivingWorker archiving)
            : base(antimalware, validation, cdmImport, cdmSubscriptionExport, delivery, archiving)
        {
        }
    }
}
