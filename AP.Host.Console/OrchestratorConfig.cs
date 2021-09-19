using AP.Gateways.AP;
using AP.Gateways.CSN;
using AP.Gateways.Institution;
using AP.Processing;
using AP.Processing.Async;
using AP.Processing.Async.Antimalware;
using AP.Processing.Async.DocumentValidation;
using AP.Processing.Async.Forwarding;
using AP.Processing.Async.Synchronization.CDM.Import;
using AP.Processing.Async.Synchronization.CDM.Report;
using AP.Processing.Async.Synchronization.CDM.Request;
using AP.Processing.Async.Synchronization.CDM.Subscriptions;
using AP.Processing.Async.Synchronization.IR.Import;
using AP.Processing.Async.Synchronization.IR.Request;
using AP.Processing.Async.Synchronization.IR.Subscriptions;

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
            switch (message.EnvelopeType)
            {
                case EnvelopeType.UserMessage:
                    switch (message.Url)
                    {
                        case "/Business/Inbound": return new Workflow(
                            store.Get<AntimalwareWorker<ApGateway>>(),
                            store.Get<DocumentValidationWorker<ApGateway>>(),
                            store.Get<ForwardingWorker<InstitutionGateway>>());
                        case "/Business/Outbox": return new Workflow(
                            store.Get<AntimalwareWorker<InstitutionGateway>>(),
                            store.Get<DocumentValidationWorker<InstitutionGateway>>(),
                            store.Get<ForwardingWorker<ApGateway>>());
                        case "/System/Inbound":
                            switch (message.DocumentType)
                            {
                                case "SYN001": return new Workflow(
                                     store.Get<AntimalwareWorker<CsnGateway>>(),
                                     store.Get<DocumentValidationWorker<CsnGateway>>(),
                                     store.Get<IrImportWorker>(),
                                     store.Get<IrSubscriptionsWorker>());
                                case "SYN003": return new Workflow(
                                     store.Get<AntimalwareWorker<CsnGateway>>(),
                                     store.Get<DocumentValidationWorker<CsnGateway>>(),
                                     store.Get<CdmImportWorker>(),
                                     store.Get<CdmSubscriptionsWorker>());
                                case "SYN005": return new Workflow(
                                     store.Get<AntimalwareWorker<CsnGateway>>(),
                                     store.Get<DocumentValidationWorker<CsnGateway>>(),
                                     store.Get<CdmReportWorker<CsnGateway>>());
                            }
                            break;
                        case "/System/Outbox":
                            switch (message.DocumentType)
                            {
                                case "SYN002": return new Workflow(
                                     store.Get<AntimalwareWorker<InstitutionGateway>>(),
                                     store.Get<DocumentValidationWorker<InstitutionGateway>>(),
                                     store.Get<IrRequestWorker>());
                                case "SYN004": return new Workflow(
                                     store.Get<AntimalwareWorker<InstitutionGateway>>(),
                                     store.Get<DocumentValidationWorker<InstitutionGateway>>(),
                                     store.Get<CdmRequestWorker>());
                            }
                            break;
                    }
                    break;
                case EnvelopeType.Signal:
                    switch (message.Url)
                    {
                        case "Business/Inbound":
                        case "System/Inbound": return new Workflow(
                            store.Get<AntimalwareWorker<ApGateway>>(),
                            store.Get<ForwardingWorker<InstitutionGateway>>());
                        case "Business/Outbox":
                        case "System/Outbox": return new Workflow(
                            store.Get<AntimalwareWorker<InstitutionGateway>>(),
                            store.Get<ForwardingWorker<ApGateway>>());
                    }
                    break;
            }
            
            throw new System.Exception("Invalid url");
        }
    }
}
