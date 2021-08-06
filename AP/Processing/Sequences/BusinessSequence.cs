using AP.Processing.Workers;

namespace AP.Processing.Sequences
{
    public class BusinessSequence: Sequence
    {
        public BusinessSequence(
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            DeliveryWorker delivery,
            ArchivingWorker archiving)
            : base(antimalware, validation, delivery, archiving)
        {
        }
    }
}
