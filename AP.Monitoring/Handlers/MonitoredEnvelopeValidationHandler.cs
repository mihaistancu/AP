using AP.Processing;
using AP.Processing.Sync;
using AP.Processing.Sync.EnvelopeValidation;

namespace AP.Monitoring.Handlers
{
    public class MonitoredEnvelopeValidationHandler : EnvelopeValidationHandler
    {
        public MonitoredEnvelopeValidationHandler(
            IEnvelopeValidator validator, 
            IEnvelopeValidationErrorFactory errorFactory) 
            : base(validator, errorFactory)
        {
        }

        public override void Handle(Message message, IOutput output)
        {
            System.Console.WriteLine("Envelope Validation");
            base.Handle(message, output);
        }
    }
}
