using AP.Data;
using AP.Processing.Async;
using AP.Processing.Async.Workers.Antimalware;
using AP.Processing.Async.Workers.CDM.Export;
using AP.Processing.Async.Workers.CDM.Import;
using AP.Processing.Async.Workers.CDM.Report;
using AP.Processing.Async.Workers.Delivery;
using AP.Processing.Async.Workers.IR.Export;
using AP.Processing.Async.Workers.IR.Import;
using AP.Processing.Async.Workers.Validation;

namespace AP.Host.Console
{
    public class OrchestratorConfig: IOrchestratorConfig
    {
        private Store store;

        public OrchestratorConfig(Store store)
        {
            this.store = store;
        }

        public Workflow GetWorkflow(Message message)
        {
            switch (message.Type)
            {
                case MessageType.Business: return GetBusinessWorkflow();
                case MessageType.System: return GetSystemWorkflow(message);
                case MessageType.Receipt: return GetReceiptWorkflow();
                case MessageType.Error: return GetErrorWorkflow();
            }
            throw new System.Exception("Unknown message type");
        }

        public Workflow GetBusinessWorkflow()
        {
            return new Workflow(
                store.Get<AntimalwareWorker>(),
                store.Get<ValidationWorker>(),
                store.Get<DeliveryWorker>());
        }

        public Workflow GetSystemWorkflow(Message message)
        {
            switch (message.DocumentType)
            {
                case "SYN001": return new Workflow(
                    store.Get<AntimalwareWorker>(),
                    store.Get<ValidationWorker>(),
                    store.Get<IrImportWorker>(),
                    store.Get<IrSubscriptionExportWorker>());

                case "SYN002": return new Workflow(
                    store.Get<AntimalwareWorker>(),
                    store.Get<ValidationWorker>(),
                    store.Get<IrRequestExportWorker>());

                case "SYN003": return new Workflow(
                    store.Get<AntimalwareWorker>(),
                    store.Get<ValidationWorker>(),
                    store.Get<CdmImportWorker>(),
                    store.Get<CdmSubscriptionExportWorker>());

                case "SYN004": return new Workflow(
                    store.Get<AntimalwareWorker>(),
                    store.Get<ValidationWorker>(),
                    store.Get<CdmRequestExportWorker>());

                case "SYN005": return new Workflow(
                    store.Get<AntimalwareWorker>(),
                    store.Get<ValidationWorker>(),
                    store.Get<CdmVersionReportWorker>());
            }

            throw new System.Exception("Unknown document type");
        }

        public Workflow GetReceiptWorkflow()
        {
            return new Workflow(
                store.Get<AntimalwareWorker>(),
                store.Get<DeliveryWorker>());
        }

        public Workflow GetErrorWorkflow()
        {
            return new Workflow(
                store.Get<AntimalwareWorker>(),
                store.Get<DeliveryWorker>());
        }
    }
}
