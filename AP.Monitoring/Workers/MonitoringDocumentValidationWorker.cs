using AP.Processing;
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
            IRouter router) 
            : base(validator, errorFactory, storage, router)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Document Validation");
            return base.Handle(message);
        }
    }
}
