using AP.Processing.Workers.Antimalware;
using AP.Processing.Workers.CDM;
using AP.Processing.Workers.Delivery;
using AP.Processing.Workers.Validation;

namespace AP.Processing.Workflows
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
