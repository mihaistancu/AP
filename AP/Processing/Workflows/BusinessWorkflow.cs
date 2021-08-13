using AP.Processing.Workers;

namespace AP.Processing.Workflows
{
    public class BusinessWorkflow : LinearWorkflow
    {
        public BusinessWorkflow(
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            DeliveryWorker delivery,
            ArchivingWorker archiving)
            : base(new WorkerSequence(antimalware, validation, delivery, archiving))
        {
        }
    }
}
