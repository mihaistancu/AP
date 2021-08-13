using AP.Processing.Workers;

namespace AP.Processing.Workflows
{
    public class CdmVersionWorkflow : LinearWorkflow
    {
        public CdmVersionWorkflow(
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            CdmVersionReportWorker cdmVersionReport,
            DeliveryWorker delivery,
            ArchivingWorker archiving)
            : base(new WorkerSequence(antimalware, validation, cdmVersionReport, delivery, archiving))
        {
        }
    }
}
