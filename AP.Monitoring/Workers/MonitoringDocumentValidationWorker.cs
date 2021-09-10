using AP.Data;
using AP.Processing.Async.Workers.DocumentValidation;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringDocumentValidationWorker: DocumentValidationWorker
    {
        public MonitoringDocumentValidationWorker(IDocumentValidator validator) : base(validator)
        {
        }

        public override Message[] Handle(Message message)
        {
            Console.WriteLine("Document Validation");
            return base.Handle(message);
        }
    }
}
