using AP.Data;
using AP.Processing.Async.Workers.Validation;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringValidationWorker: ValidationWorker
    {
        public MonitoringValidationWorker(IDocumentValidator validator) : base(validator)
        {
        }

        public override Message[] Handle(Message message)
        {
            Console.WriteLine("Validation");
            return base.Handle(message);
        }
    }
}
