using AP.Async.Workers.Antimalware;
using AP.Async.Workers.CDM.Export;
using AP.Async.Workers.Delivery;
using AP.Async.Workers.Validation;

namespace AP.Async.Workflows
{
    public class CdmRequestWorkflow : LinearWorkflow
    {
        public CdmRequestWorkflow(
            IMessageBroker broker,
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            CdmRequestExportWorker cdmRequestExport,
            DeliveryWorker delivery)
            : base(broker, antimalware, validation, cdmRequestExport, delivery)
        {
        }
    }
}
