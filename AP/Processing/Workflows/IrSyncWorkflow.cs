using AP.Processing.Workers;

namespace AP.Processing.Sequences
{
    public class IrSyncWorkflow: LinearWorkflow
    {
        public IrSyncWorkflow(
            IMessageBroker broker,
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            IrImportWorker irImport,
            IrSubscriptionExportWorker irSubscriptionExport,
            DeliveryWorker delivery,
            ArchivingWorker archiving)
            : base(broker, new WorkerSequence(antimalware, validation, irImport, irSubscriptionExport, delivery, archiving))
        {
        }
    }
}
