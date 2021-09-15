using AP.Processing;
using AP.Processing.Sync.SignatureValidation;

namespace AP.Monitoring.Handlers
{
    public class MonitoringSignatureValidationHandler : SignatureValidationHandler
    {
        public MonitoringSignatureValidationHandler(
            IEnvelopeSignatureValidator validator, 
            IEnvelopeSignatureValidationErrorFactory errorFactory) 
            : base(validator, errorFactory)
        {
        }

        public override (bool, Message) Handle(Message message)
        {
            System.Console.WriteLine("Signature Validation");
            return base.Handle(message);
        }
    }
}
