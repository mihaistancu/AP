using AP.Processing;
using AP.Processing.Async;
using AP.Processing.Async.Antimalware;
using AP.Processing.Async.CDM.Export;
using AP.Processing.Async.CDM.Import;
using AP.Processing.Async.CDM.Report;
using AP.Processing.Async.CDM.Request;
using AP.Processing.Async.Delivery;
using AP.Processing.Async.DocumentValidation;
using AP.Processing.Async.IR.Import;
using AP.Processing.Async.IR.Request;
using AP.Processing.Async.IR.Subscriptions;

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
            switch (message.Direction)
            {
                case Direction.In: return GetIncomingWorkflow(message);
                case Direction.Out: return GetOutgoingWorkflow();
            }
            throw new System.Exception("Unknown message direction");
        }

        public Workflow GetOutgoingWorkflow()
        {
            return new Workflow(store.Get<DeliveryWorker>());
        }

        public Workflow GetIncomingWorkflow(Message message)
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
                store.Get<DocumentValidationWorker>(),
                store.Get<DeliveryWorker>());
        }

        public Workflow GetSystemWorkflow(Message message)
        {
            switch (message.DocumentType)
            {
                case "SYN001": return new Workflow(
                    store.Get<AntimalwareWorker>(),
                    store.Get<DocumentValidationWorker>(),
                    store.Get<IrImportWorker>(),
                    store.Get<IrSubscriptionsExportWorker>());

                case "SYN002": return new Workflow(
                    store.Get<AntimalwareWorker>(),
                    store.Get<DocumentValidationWorker>(),
                    store.Get<IrRequestWorker>());

                case "SYN003": return new Workflow(
                    store.Get<AntimalwareWorker>(),
                    store.Get<DocumentValidationWorker>(),
                    store.Get<CdmImportWorker>(),
                    store.Get<CdmSubscriptionsWorker>());

                case "SYN004": return new Workflow(
                    store.Get<AntimalwareWorker>(),
                    store.Get<DocumentValidationWorker>(),
                    store.Get<CdmRequestWorker>());

                case "SYN005": return new Workflow(
                    store.Get<AntimalwareWorker>(),
                    store.Get<DocumentValidationWorker>(),
                    store.Get<CdmReportWorker>());
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
