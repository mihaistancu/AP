using AP.Processing.Workers;

namespace AP.Processing.Sequences
{
    public class CdmRequestWorkflow: LinearWorkflow
    {
        public CdmRequestWorkflow(
            IMessageBroker broker,
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            CdmRequestExportWorker cdmRequestExport,
            DeliveryWorker delivery,
            ArchivingWorker archiving)
            : base(broker, new WorkerSequence(antimalware, validation, cdmRequestExport, delivery, archiving))
        {
        }
    }
}
