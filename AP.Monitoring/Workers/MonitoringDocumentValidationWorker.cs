using AP.Data;
using AP.Processing.Async.DocumentValidation;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringDocumentValidationWorker: DocumentValidationWorker
    {
        public MonitoringDocumentValidationWorker(IDocumentValidator validator) : base(validator)
        {
        }

        public override void Handle(Message message)
        {
            Console.WriteLine("Document Validation");
            base.Handle(message);
        }
    }
}
