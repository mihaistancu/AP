using AP.Async.Workers.Antimalware;
using AP.Async.Workers.CDM.Report;
using AP.Async.Workers.Delivery;
using AP.Async.Workers.Validation;

namespace AP.Async.Workflows
{
    public class CdmVersionWorkflow : Workflow
    {
        public CdmVersionWorkflow(
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            CdmVersionReportWorker cdmVersionReport,
            DeliveryWorker delivery)
            : base(antimalware, validation, cdmVersionReport, delivery)
        {
        }
    }
}
