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
    public class MessagingOrchestrator
    {
        private Orchestrator orchestrator;
        private Store store;

        public MessagingOrchestrator(Orchestrator orchestrator, Store store)
        {
            this.orchestrator = orchestrator;
            this.store = store;
        }

        public void Start()
        {
            orchestrator.Use(new Route 
            { 
                UseCase = UseCase.Business,
                Domain = Domain.International,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "*",
                Workflow = new Workflow(
                    store.Get<AntimalwareWorker<ApGateway>>(),
                    store.Get<DocumentValidationWorker<ApGateway>>(),
                    store.Get<ForwardingWorker<InstitutionGateway>>())
            });

            orchestrator.Use(new Route
            {
                UseCase = UseCase.Business,
                Domain = Domain.National,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "*",
                Workflow = new Workflow(
                    store.Get<AntimalwareWorker<InstitutionGateway>>(),
                    store.Get<DocumentValidationWorker<InstitutionGateway>>(),
                    store.Get<ForwardingWorker<ApGateway>>())
            });

            orchestrator.Use(new Route
            {
                UseCase = UseCase.System,
                Domain = Domain.International,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "SYN001",
                Workflow = new Workflow(
                    store.Get<AntimalwareWorker<CsnGateway>>(),
                    store.Get<DocumentValidationWorker<CsnGateway>>(),
                    store.Get<IrImportWorker>(),
                    store.Get<IrSubscriptionsWorker>())
            });

            orchestrator.Use(new Route
            {
                UseCase = UseCase.System,
                Domain = Domain.International,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "SYN003",
                Workflow = new Workflow(
                    store.Get<AntimalwareWorker<CsnGateway>>(),
                    store.Get<DocumentValidationWorker<CsnGateway>>(),
                    store.Get<CdmImportWorker>(),
                    store.Get<CdmSubscriptionsWorker>())
            });

            orchestrator.Use(new Route
            {
                UseCase = UseCase.System,
                Domain = Domain.International,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "SYN005",
                Workflow = new Workflow(
                    store.Get<AntimalwareWorker<CsnGateway>>(),
                    store.Get<DocumentValidationWorker<CsnGateway>>(),
                    store.Get<CdmReportWorker<CsnGateway>>())
            });

            orchestrator.Use(new Route
            {
                UseCase = UseCase.System,
                Domain = Domain.National,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "SYN002",
                Workflow = new Workflow(
                    store.Get<AntimalwareWorker<InstitutionGateway>>(),
                    store.Get<DocumentValidationWorker<InstitutionGateway>>(),
                    store.Get<IrRequestWorker>())
            });

            orchestrator.Use(new Route
            {
                UseCase = UseCase.System,
                Domain = Domain.National,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "SYN004",
                Workflow = new Workflow(
                    store.Get<AntimalwareWorker<InstitutionGateway>>(),
                    store.Get<DocumentValidationWorker<InstitutionGateway>>(),
                    store.Get<CdmRequestWorker>())
            });

            orchestrator.Use(new Route
            {
                UseCase = "*",
                Domain = Domain.International,
                EnvelopeType = EnvelopeType.Signal,
                DocumentType = "*",
                Workflow = new Workflow(
                    store.Get<AntimalwareWorker<ApGateway>>(),
                    store.Get<ForwardingWorker<InstitutionGateway>>())
            });

            orchestrator.Use(new Route
            {
                UseCase = "*",
                Domain = Domain.National,
                EnvelopeType = EnvelopeType.Signal,
                DocumentType = "*",
                Workflow = new Workflow(
                    store.Get<AntimalwareWorker<InstitutionGateway>>(),
                    store.Get<ForwardingWorker<ApGateway>>())
            });

            orchestrator.Start();
        }
    }
}
