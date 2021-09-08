using AP.Processing.Async.Workers.Antimalware;
using AP.Processing.Async.Workers.CDM.Report;
using AP.Processing.Async.Workers.Delivery;
using AP.Processing.Async.Workers.Validation;

namespace AP.Processing.Async.Workflows
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
