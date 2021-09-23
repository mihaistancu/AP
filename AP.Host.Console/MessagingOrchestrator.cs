using AP.Processing;
using AP.Processing.Async;

namespace AP.Host.Console
{
    public class MessagingOrchestrator
    {
        private Orchestrator orchestrator;
        private Workers workers;

        public MessagingOrchestrator(Orchestrator orchestrator, Workers workers)
        {
            this.orchestrator = orchestrator;
            this.workers = workers;
        }

        public void Start()
        {
            orchestrator.Use(new Rule 
            { 
                UseCase = UseCase.Business,
                Domain = Domain.International,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "*",
                Workflow = new Workflow(
                    workers.ScanMessageFromAp,
                    workers.ValidateDocumentFromAp,
                    workers.ForwardToInstitution)
            });

            orchestrator.Use(new Rule
            {
                UseCase = UseCase.Business,
                Domain = Domain.National,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "*",
                Workflow = new Workflow(
                    workers.ScanMessageFromInstitution,
                    workers.ValidateDocumentFromInstitution,
                    workers.ForwardToAp)
            });

            orchestrator.Use(new Rule
            {
                UseCase = UseCase.System,
                Domain = Domain.International,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "SYN001",
                Workflow = new Workflow(
                    workers.ScanMessageFromCsn,
                    workers.ValidateDocumentFromCsn,
                    workers.ImportIr,
                    workers.PublishIr)
            });

            orchestrator.Use(new Rule
            {
                UseCase = UseCase.System,
                Domain = Domain.International,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "SYN003",
                Workflow = new Workflow(
                    workers.ScanMessageFromCsn,
                    workers.ValidateDocumentFromCsn,
                    workers.ImportCdm,
                    workers.PublishCdm)
            });

            orchestrator.Use(new Rule
            {
                UseCase = UseCase.System,
                Domain = Domain.International,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "SYN005",
                Workflow = new Workflow(
                    workers.ScanMessageFromCsn,
                    workers.ValidateDocumentFromCsn,
                    workers.ReportCdm)
            });

            orchestrator.Use(new Rule
            {
                UseCase = UseCase.System,
                Domain = Domain.National,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "SYN002",
                Workflow = new Workflow(
                    workers.ScanMessageFromInstitution,
                    workers.ValidateDocumentFromInstitution,
                    workers.ProvideIr)
            });

            orchestrator.Use(new Rule
            {
                UseCase = UseCase.System,
                Domain = Domain.National,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "SYN004",
                Workflow = new Workflow(
                    workers.ScanMessageFromInstitution,
                    workers.ValidateDocumentFromInstitution,
                    workers.ProvideCdm)
            });

            orchestrator.Use(new Rule
            {
                UseCase = "*",
                Domain = Domain.International,
                EnvelopeType = EnvelopeType.Signal,
                DocumentType = "*",
                Workflow = new Workflow(
                    workers.ScanMessageFromAp,
                    workers.ForwardToInstitution)
            });

            orchestrator.Use(new Rule
            {
                UseCase = "*",
                Domain = Domain.National,
                EnvelopeType = EnvelopeType.Signal,
                DocumentType = "*",
                Workflow = new Workflow(
                    workers.ScanMessageFromInstitution,
                    workers.ForwardToAp)
            });

            orchestrator.Start();
        }
    }
}
