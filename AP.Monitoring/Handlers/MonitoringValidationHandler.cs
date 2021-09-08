﻿using AP.Processing.Sync.Handlers.Validation;

namespace AP.Monitoring.Handlers
{
    public class MonitoringValidationHandler : ValidationHandler
    {
        public MonitoringValidationHandler(IEnvelopeValidator validator) : base(validator)
        {
        }

        public override bool Handle(Message message)
        {
            System.Console.WriteLine("Validation");
            return base.Handle(message);
        }
    }
}
