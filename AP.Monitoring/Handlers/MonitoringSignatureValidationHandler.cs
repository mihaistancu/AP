using AP.Data;
using AP.Processing.Sync;
using AP.Processing.Sync.SignatureValidation;

namespace AP.Monitoring.Handlers
{
    public class MonitoringSignatureValidationHandler : SignatureValidationHandler
    {
        public MonitoringSignatureValidationHandler(IEnvelopeSignatureValidator validator) : base(validator)
        {
        }

        public override bool Handle(Message message, IOutput output)
        {
            System.Console.WriteLine("Signature Check");
            return base.Handle(message, output);
        }
    }
}
