using AP.Messaging;
using System.Collections.Generic;
using System.Linq;

namespace AP.Orchestration
{
    public class OrchestratorConfig
    {
        private List<OrchestratorRule> rules = new List<OrchestratorRule>();

        public void Load()
        {
            rules.Add(new OrchestratorRule
            {
                UseCase = UseCase.Business,
                Domain = Domain.International,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "*",
                Workflow = new Workflow(
                    Worker.ScanMessageFromAp,
                    Worker.ValidateDocumentFromAp,
                    Worker.ForwardToInstitution)
            });

            rules.Add(new OrchestratorRule
            {
                UseCase = UseCase.Business,
                Domain = Domain.National,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "*",
                Workflow = new Workflow(
                    Worker.ScanMessageFromInstitution,
                    Worker.ValidateDocumentFromInstitution,
                    Worker.ForwardToAp)
            });

            rules.Add(new OrchestratorRule
            {
                UseCase = UseCase.System,
                Domain = Domain.International,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "SYN001",
                Workflow = new Workflow(
                    Worker.ScanMessageFromCsn,
                    Worker.ValidateDocumentFromCsn,
                    Worker.ImportIr,
                    Worker.PublishIr)
            });

            rules.Add(new OrchestratorRule
            {
                UseCase = UseCase.System,
                Domain = Domain.International,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "SYN003",
                Workflow = new Workflow(
                    Worker.ScanMessageFromCsn,
                    Worker.ValidateDocumentFromCsn,
                    Worker.ImportCdm,
                    Worker.PublishCdm)
            });

            rules.Add(new OrchestratorRule
            {
                UseCase = UseCase.System,
                Domain = Domain.International,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "SYN005",
                Workflow = new Workflow(
                    Worker.ScanMessageFromCsn,
                    Worker.ValidateDocumentFromCsn,
                    Worker.ReportCdm)
            });

            rules.Add(new OrchestratorRule
            {
                UseCase = UseCase.System,
                Domain = Domain.National,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "SYN002",
                Workflow = new Workflow(
                    Worker.ScanMessageFromInstitution,
                    Worker.ValidateDocumentFromInstitution,
                    Worker.ProvideIr)
            });

            rules.Add(new OrchestratorRule
            {
                UseCase = UseCase.System,
                Domain = Domain.National,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "SYN004",
                Workflow = new Workflow(
                    Worker.ScanMessageFromInstitution,
                    Worker.ValidateDocumentFromInstitution,
                    Worker.ProvideCdm)
            });

            rules.Add(new OrchestratorRule
            {
                UseCase = "*",
                Domain = Domain.International,
                EnvelopeType = EnvelopeType.Signal,
                DocumentType = "*",
                Workflow = new Workflow(
                    Worker.ScanMessageFromAp,
                    Worker.ForwardToInstitution)
            });

            rules.Add(new OrchestratorRule
            {
                UseCase = "*",
                Domain = Domain.National,
                EnvelopeType = EnvelopeType.Signal,
                DocumentType = "*",
                Workflow = new Workflow(
                    Worker.ScanMessageFromInstitution,
                    Worker.ForwardToAp)
            });
        }

        public Workflow GetWorkflow(Message message)
        {
            return rules.First(rule => rule.Matches(message)).Workflow;
        }
    }
}
