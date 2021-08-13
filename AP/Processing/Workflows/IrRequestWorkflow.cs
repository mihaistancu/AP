using AP.Processing.Workers;

namespace AP.Processing.Workflows
{
    public class IrRequestWorkflow : LinearWorkflow
    {
        public IrRequestWorkflow(
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            IrRequestExportWorker irRequestExport,
            DeliveryWorker delivery,
            ArchivingWorker archiving)
            : base(new WorkerSequence(antimalware, validation, irRequestExport, delivery, archiving))
        {
        }
    }
}
