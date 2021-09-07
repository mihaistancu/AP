using AP.Async.Workers.Antimalware;
using AP.Async.Workers.CDM.Export;
using AP.Async.Workers.Delivery;
using AP.Async.Workers.Validation;

namespace AP.Async.Workflows
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
