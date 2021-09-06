using AP.Processing.Workers;
using AP.Processing.Workers.Antimalware;

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
