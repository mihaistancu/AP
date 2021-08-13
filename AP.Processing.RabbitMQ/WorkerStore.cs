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
                {"antimalware", antimalware },
                {"archiving", archiving },
                {"cdmImport", cdmImport },
                {"cdmRequestExport", cdmRequestExport },
                {"cdmSubscriptionExport", cdmSubscriptionExport },
                {"cdmVersionReport", cdmVersionReport },
                {"delivery", delivery },
                {"irImport", irImport },
                {"irRequestExport", irRequestExport },
                {"irSubscriptionExport", irSubscriptionExport },
                {"validation", validation }
            };
        }

        public IWorker Get(string key)
        {
            return workers[key];
        }
    }
}
