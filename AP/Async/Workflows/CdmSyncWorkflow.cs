using AP.Async.Workers.Antimalware;
using AP.Async.Workers.CDM;
using AP.Async.Workers.Delivery;
using AP.Async.Workers.Validation;

namespace AP.Async.Workflows
{
    public class CdmSyncWorkflow : LinearWorkflow
    {
        public CdmSyncWorkflow(
            IMessageBroker broker,
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            CdmImportWorker cdmImport,
            CdmSubscriptionExportWorker cdmSubscriptionExport,
            DeliveryWorker delivery)
            : base(broker, antimalware, validation, cdmImport, cdmSubscriptionExport, delivery)
        {
        }
    }
}
