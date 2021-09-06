using AP.Processing.Workers.Antimalware;
using AP.Processing.Workers.CDM;
using AP.Processing.Workers.Delivery;
using AP.Processing.Workers.Validation;

namespace AP.Processing.Workflows
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
