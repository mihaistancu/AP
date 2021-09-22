using AP.Processing;
using AP.Processing.Sync;
using AP.Processing.Sync.SignatureValidation;

namespace AP.Monitoring.Handlers
{
    public class MonitoredSignatureValidationHandler : SignatureValidationHandler
    {
        public MonitoredSignatureValidationHandler(
            IEnvelopeSignatureValidator validator, 
            IEnvelopeSignatureValidationErrorFactory errorFactory) 
            : base(validator, errorFactory)
        {
        }

        public override void Handle(Message message, IOutput output)
        {
            System.Console.WriteLine("Signature Validation");
            base.Handle(message, output);
        }
    }
}
