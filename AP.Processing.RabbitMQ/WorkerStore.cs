using AP.Processing.Workers;
using System.Collections.Generic;

namespace AP.Processing.RabbitMQ
{
    public class WorkerStore
    {
        private Dictionary<string, IWorker> workers;

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
            ValidationWorker validation)
        {
            workers = new Dictionary<string, IWorker>
            {
                {Id(antimalware), antimalware },
                {Id(archiving), archiving },
                {Id(cdmImport), cdmImport },
                {Id(cdmRequestExport), cdmRequestExport },
                {Id(cdmSubscriptionExport), cdmSubscriptionExport },
                {Id(cdmVersionReport), cdmVersionReport },
                {Id(delivery), delivery },
                {Id(irImport), irImport },
                {Id(irRequestExport), irRequestExport },
                {Id(irSubscriptionExport), irSubscriptionExport },
                {Id(validation), validation }
            };
        }

        public IWorker GetWorker(string id)
        {
            return workers[id];
        }

        public string GetKey(IWorker worker)
        {
            return Id(worker);
        }

        private string Id(IWorker worker)
        {
            return worker.GetType().Name;
        }
    }
}
