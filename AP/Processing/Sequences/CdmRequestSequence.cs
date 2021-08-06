using AP.Processing.Workers;

namespace AP.Processing.Sequences
{
    public class CdmRequestSequence: Sequence
    {
        public CdmRequestSequence(
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            CdmRequestExportWorker cdmRequestExport,
            DeliveryWorker delivery,
            ArchivingWorker archiving)
            : base(antimalware, validation, cdmRequestExport, delivery, archiving)
        {
        }
    }
}
