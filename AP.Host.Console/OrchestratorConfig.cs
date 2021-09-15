using AP.Gateways.AP;
using AP.Gateways.CSN;
using AP.Gateways.Institution;
using AP.Processing;
using AP.Processing.Async;
using AP.Processing.Async.Antimalware;
using AP.Processing.Async.CDM.Import;
using AP.Processing.Async.CDM.Report;
using AP.Processing.Async.CDM.Request;
using AP.Processing.Async.CDM.Subscriptions;
using AP.Processing.Async.DocumentValidation;
using AP.Processing.Async.Forwarding;
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
            switch (message.Type)
            {
                case MessageType.Business: return GetBusinessWorkflow(message);
                case MessageType.System: return GetSystemWorkflow(message);
                case MessageType.Signal: return GetSignalWorkflow(message);
            }
            throw new System.Exception("Unknown message type");
        }

        public Workflow GetBusinessWorkflow(Message message)
        {
            switch (message.Channel)
            {
                case Channel.Inbound: return new Workflow(
                    store.Get<AntimalwareWorker<ApGateway>>(),
                    store.Get<DocumentValidationWorker<ApGateway>>(),
                    store.Get<ForwardingWorker<InstitutionGateway>>());
                case Channel.Outbox: return new Workflow(
                    store.Get<AntimalwareWorker<InstitutionGateway>>(),
                    store.Get<DocumentValidationWorker<InstitutionGateway>>(),
                    store.Get<ForwardingWorker<ApGateway>>());
            }
            throw new System.Exception("Unknown message channel");
        }

        public Workflow GetSystemWorkflow(Message message)
        {
            switch (message.DocumentType)
            {
                case "SYN001": return new Workflow(
                    store.Get<AntimalwareWorker<CsnGateway>>(),
                    store.Get<DocumentValidationWorker<CsnGateway>>(),
                    store.Get<IrImportWorker>(),
                    store.Get<IrSubscriptionsWorker>());

                case "SYN002": return new Workflow(
                    store.Get<AntimalwareWorker<InstitutionGateway>>(),
                    store.Get<DocumentValidationWorker<InstitutionGateway>>(),
                    store.Get<IrRequestWorker>());

                case "SYN003": return new Workflow(
                    store.Get<AntimalwareWorker<CsnGateway>>(),
                    store.Get<DocumentValidationWorker<CsnGateway>>(),
                    store.Get<CdmImportWorker>(),
                    store.Get<CdmSubscriptionsWorker>());

                case "SYN004": return new Workflow(
                    store.Get<AntimalwareWorker<InstitutionGateway>>(),
                    store.Get<DocumentValidationWorker<InstitutionGateway>>(),
                    store.Get<CdmRequestWorker>());

                case "SYN005": return new Workflow(
                    store.Get<AntimalwareWorker<CsnGateway>>(),
                    store.Get<DocumentValidationWorker<CsnGateway>>(),
                    store.Get<CdmReportWorker<CsnGateway>>());
            }

            throw new System.Exception("Unknown document type");
        }

        public Workflow GetSignalWorkflow(Message message)
        {
            switch (message.Channel)
            {
                case Channel.Inbound: return new Workflow(
                    store.Get<AntimalwareWorker<ApGateway>>(),
                    store.Get<ForwardingWorker<InstitutionGateway>>());
                case Channel.Outbox: return new Workflow(
                    store.Get<AntimalwareWorker<InstitutionGateway>>(),
                    store.Get<ForwardingWorker<ApGateway>>());
            }
            throw new System.Exception("Unknown message channel");
        }
    }
}
