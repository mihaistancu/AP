using AP.Data;
using AP.Processing.Sync.Handlers.SignatureValidation;

namespace AP.Monitoring.Handlers
{
    public class MonitoringSignatureValidationHandler : SignatureValidationHandler
    {
        public MonitoringSignatureValidationHandler(IEnvelopeSignatureValidator validator) : base(validator)
        {
        }

        public override bool Handle(Message message)
        {
            System.Console.WriteLine("Signature Check");
            return base.Handle(message);
        }
    }
}
