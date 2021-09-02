using AP.Processing.Workers;

namespace AP.Processing.RabbitMQ.Serialization.Stores
{
    public class WorkerStore : Store<IWorker>
    {
        public WorkerStore(
            AntimalwareWorker antimalware,
            ArchivingWorker archiving,
            CdmImportWorker cdmImport,
            CdmRequestExportWorker cdmRequestExport,
            CdmSubscriptionExportWorker cdmSubscriptionExport,
            CdmVersionReportWorker cdmVersionReport,
            DeliveryWorker delivery,
            IrImportWorker irImport,
            IrRequestExportWorker irRequestExport,
            IrSubscriptionExportWorker irSubscriptionExport,
            ValidationWorker validation) :
            base(antimalware,
                archiving,
                cdmImport,
                cdmRequestExport,
                cdmSubscriptionExport,
                cdmVersionReport,
                delivery,
                irImport,
                irRequestExport,
                irSubscriptionExport,
                validation)
        {
        }
    }
}
