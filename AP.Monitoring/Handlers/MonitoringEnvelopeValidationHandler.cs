﻿using AP.Data;
using AP.Processing.Sync;
using AP.Processing.Sync.EnvelopeValidation;

namespace AP.Monitoring.Handlers
{
    public class MonitoringEnvelopeValidationHandler : EnvelopeValidationHandler
    {
        public MonitoringEnvelopeValidationHandler(IEnvelopeValidator validator) : base(validator)
        {
        }

        public override bool Handle(Message message, IOutput output)
        {
            System.Console.WriteLine("Envelope Validation");
            return base.Handle(message, output);
        }
    }
}
