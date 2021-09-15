using AP.Processing;
using AP.Processing.Async.DocumentValidation;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringDocumentValidationWorker<T>: DocumentValidationWorker<T> where T: IGateway
    {
        public MonitoringDocumentValidationWorker(
            IDocumentValidator validator, 
            IDocumentValidationErrorFactory errorFactory, 
            IMessageStorage storage, 
            T gateway) 
            : base(validator, errorFactory, storage, gateway)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Document Validation");
            return base.Handle(message);
        }
    }
}
