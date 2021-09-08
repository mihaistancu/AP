using AP.Processing.Async.Workers.Antimalware;
using AP.Processing.Async.Workers.Delivery;
using AP.Processing.Async.Workers.IR.Export;
using AP.Processing.Async.Workers.Validation;

namespace AP.Processing.Async.Workflows
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
