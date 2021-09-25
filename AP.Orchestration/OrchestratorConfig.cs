using System.Collections.Generic;
using System.Linq;

namespace AP.Processing.Async
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
                    Workers.ScanMessageFromAp,
                    Workers.ValidateDocumentFromAp,
                    Workers.ForwardToInstitution)
            });

            rules.Add(new OrchestratorRule
            {
                UseCase = UseCase.Business,
                Domain = Domain.National,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "*",
                Workflow = new Workflow(
                    Workers.ScanMessageFromInstitution,
                    Workers.ValidateDocumentFromInstitution,
                    Workers.ForwardToAp)
            });

            rules.Add(new OrchestratorRule
            {
                UseCase = UseCase.System,
                Domain = Domain.International,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "SYN001",
                Workflow = new Workflow(
                    Workers.ScanMessageFromCsn,
                    Workers.ValidateDocumentFromCsn,
                    Workers.ImportIr,
                    Workers.PublishIr)
            });

            rules.Add(new OrchestratorRule
            {
                UseCase = UseCase.System,
                Domain = Domain.International,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "SYN003",
                Workflow = new Workflow(
                    Workers.ScanMessageFromCsn,
                    Workers.ValidateDocumentFromCsn,
                    Workers.ImportCdm,
                    Workers.PublishCdm)
            });

            rules.Add(new OrchestratorRule
            {
                UseCase = UseCase.System,
                Domain = Domain.International,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "SYN005",
                Workflow = new Workflow(
                    Workers.ScanMessageFromCsn,
                    Workers.ValidateDocumentFromCsn,
                    Workers.ReportCdm)
            });

            rules.Add(new OrchestratorRule
            {
                UseCase = UseCase.System,
                Domain = Domain.National,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "SYN002",
                Workflow = new Workflow(
                    Workers.ScanMessageFromInstitution,
                    Workers.ValidateDocumentFromInstitution,
                    Workers.ProvideIr)
            });

            rules.Add(new OrchestratorRule
            {
                UseCase = UseCase.System,
                Domain = Domain.National,
                EnvelopeType = EnvelopeType.UserMessage,
                DocumentType = "SYN004",
                Workflow = new Workflow(
                    Workers.ScanMessageFromInstitution,
                    Workers.ValidateDocumentFromInstitution,
                    Workers.ProvideCdm)
            });

            rules.Add(new OrchestratorRule
            {
                UseCase = "*",
                Domain = Domain.International,
                EnvelopeType = EnvelopeType.Signal,
                DocumentType = "*",
                Workflow = new Workflow(
                    Workers.ScanMessageFromAp,
                    Workers.ForwardToInstitution)
            });

            rules.Add(new OrchestratorRule
            {
                UseCase = "*",
                Domain = Domain.National,
                EnvelopeType = EnvelopeType.Signal,
                DocumentType = "*",
                Workflow = new Workflow(
                    Workers.ScanMessageFromInstitution,
                    Workers.ForwardToAp)
            });
        }
        
        public Workflow GetWorkflow(Message message)
        {
            return rules.First(rule => rule.Matches(message)).Workflow;
        }
    }
}
