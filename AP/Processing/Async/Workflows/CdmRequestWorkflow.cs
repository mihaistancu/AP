using AP.Processing.Async.Workers.Antimalware;
using AP.Processing.Async.Workers.CDM.Export;
using AP.Processing.Async.Workers.Delivery;
using AP.Processing.Async.Workers.Validation;

namespace AP.Processing.Async.Workflows
{
    public class CdmRequestWorkflow : Workflow
    {
        public CdmRequestWorkflow(
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            CdmRequestExportWorker cdmRequestExport,
            DeliveryWorker delivery)
            : base(antimalware, validation, cdmRequestExport, delivery)
        {
        }
    }
}
