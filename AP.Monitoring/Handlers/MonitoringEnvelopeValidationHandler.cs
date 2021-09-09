using AP.Data;
using AP.Processing.Sync.Handlers.EnvelopeValidation;

namespace AP.Monitoring.Handlers
{
    public class MonitoringEnvelopeValidationHandler : EnvelopeValidationHandler
    {
        public MonitoringEnvelopeValidationHandler(IEnvelopeValidator validator) : base(validator)
        {
        }

        public override bool Handle(Message message)
        {
            System.Console.WriteLine("Validation");
            return base.Handle(message);
        }
    }
}
