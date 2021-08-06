using AP.Processing.Workers;

namespace AP.Processing.Sequences
{
    public class IrRequestSequence: Sequence
    {
        public IrRequestSequence(
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            IrRequestExportWorker irRequestExport,
            DeliveryWorker delivery,
            ArchivingWorker archiving)
            : base(antimalware, validation, irRequestExport, delivery, archiving)
        {
        }
    }
}
