using AP.Processing.Workers;

namespace AP.Processing.Sequences
{
    public class IrSyncSequence: Sequence
    {
        public IrSyncSequence(
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            IrImportWorker irImport,
            IrSubscriptionExportWorker irSubscriptionExport,
            DeliveryWorker delivery,
            ArchivingWorker archiving)
            : base(antimalware, validation, irImport, irSubscriptionExport, delivery, archiving)
        {
        }
    }
}
