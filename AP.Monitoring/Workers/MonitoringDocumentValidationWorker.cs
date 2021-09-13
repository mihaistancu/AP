using AP.Data;
using AP.Processing.Async;
using AP.Processing.Async.DocumentValidation;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringDocumentValidationWorker: DocumentValidationWorker
    {
        public MonitoringDocumentValidationWorker(
            IDocumentValidator validator, 
            IDocumentValidationErrorFactory errorFactory, 
            IMessageStorage storage, 
            Orchestrator orchestrator) 
            : base(validator, errorFactory, storage, orchestrator)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Document Validation");
            return base.Handle(message);
        }
    }
}
