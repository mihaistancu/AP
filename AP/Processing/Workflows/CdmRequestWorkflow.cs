using AP.Processing.Workers;

namespace AP.Processing.Workflows
{
    public class CdmRequestWorkflow : LinearWorkflow
    {
        public CdmRequestWorkflow(
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            CdmRequestExportWorker cdmRequestExport,
            DeliveryWorker delivery,
            ArchivingWorker archiving)
            : base(new WorkerSequence(antimalware, validation, cdmRequestExport, delivery, archiving))
        {
        }
    }
}
