using AP.Processing.Workers.Antimalware;
using AP.Processing.Workers.CDM;
using AP.Processing.Workers.Delivery;
using AP.Processing.Workers.Validation;

namespace AP.Processing.Workflows
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
