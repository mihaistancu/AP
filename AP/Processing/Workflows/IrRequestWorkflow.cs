using AP.Processing.Workers;

namespace AP.Processing.Sequences
{
    public class IrRequestWorkflow: LinearWorkflow
    {
        public IrRequestWorkflow(
            IMessageBroker broker,
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            IrRequestExportWorker irRequestExport,
            DeliveryWorker delivery,
            ArchivingWorker archiving)
            : base(broker, new WorkerSequence(antimalware, validation, irRequestExport, delivery, archiving))
        {
        }
    }
}
