using AP.Processing;
using AP.Processing.Sync.EnvelopeValidation;

namespace AP.Monitoring.Handlers
{
    public class MonitoringEnvelopeValidationHandler : EnvelopeValidationHandler
    {
        public MonitoringEnvelopeValidationHandler(
            IEnvelopeValidator validator, 
            IEnvelopeValidationErrorFactory errorFactory) 
            : base(validator, errorFactory)
        {
        }

        public override (bool, Message) Handle(Message message)
        {
            System.Console.WriteLine("Envelope Validation");
            return base.Handle(message);
        }
    }
}
