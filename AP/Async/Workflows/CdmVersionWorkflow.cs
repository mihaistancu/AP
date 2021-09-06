using AP.Async.Workers.Antimalware;
using AP.Async.Workers.CDM;
using AP.Async.Workers.Delivery;
using AP.Async.Workers.Validation;

namespace AP.Async.Workflows
{
    public class CdmVersionWorkflow : LinearWorkflow
    {
        public CdmVersionWorkflow(
            IMessageBroker broker,
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            CdmVersionReportWorker cdmVersionReport,
            DeliveryWorker delivery)
            : base(broker, antimalware, validation, cdmVersionReport, delivery)
        {
        }
    }
}
