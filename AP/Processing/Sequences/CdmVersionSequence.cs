using AP.Processing.Workers;

namespace AP.Processing.Sequences
{
    public class CdmVersionSequence: Sequence
    {
        public CdmVersionSequence(
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            CdmVersionReportWorker cdmVersionReport,
            DeliveryWorker delivery,
            ArchivingWorker archiving)
            : base(antimalware, validation, cdmVersionReport, delivery, archiving)
        {
        }
    }
}
