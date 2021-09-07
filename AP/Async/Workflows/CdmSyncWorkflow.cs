using AP.Async.Workers.Antimalware;
using AP.Async.Workers.CDM.Export;
using AP.Async.Workers.CDM.Import;
using AP.Async.Workers.Delivery;
using AP.Async.Workers.Validation;

namespace AP.Async.Workflows
{
    public class CdmSyncWorkflow : Workflow
    {
        public CdmSyncWorkflow(
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            CdmImportWorker cdmImport,
            CdmSubscriptionExportWorker cdmSubscriptionExport,
            DeliveryWorker delivery)
            : base(antimalware, validation, cdmImport, cdmSubscriptionExport, delivery)
        {
        }
    }
}
