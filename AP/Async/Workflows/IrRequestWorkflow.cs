using AP.Async.Workers.Antimalware;
using AP.Async.Workers.Delivery;
using AP.Async.Workers.IR.Export;
using AP.Async.Workers.Validation;

namespace AP.Async.Workflows
{
    public class IrRequestWorkflow : Workflow
    {
        public IrRequestWorkflow(
            AntimalwareWorker antimalware,
            ValidationWorker validation,
            IrRequestExportWorker irRequestExport,
            DeliveryWorker delivery)
            : base(antimalware, validation, irRequestExport, delivery)
        {
        }
    }
}
