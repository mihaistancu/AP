using AP.Processing.Async.Workers.Antimalware;
using AP.Processing.Async.Workers.CDM.Export;
using AP.Processing.Async.Workers.CDM.Import;
using AP.Processing.Async.Workers.Delivery;
using AP.Processing.Async.Workers.Validation;

namespace AP.Processing.Async.Workflows
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
