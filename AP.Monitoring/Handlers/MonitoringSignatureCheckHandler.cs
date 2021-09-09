using AP.Data;
using AP.Processing.Sync.Handlers.SignatureCheck;

namespace AP.Monitoring.Handlers
{
    public class MonitoringSignatureCheckHandler : SignatureValidationHandler
    {
        public MonitoringSignatureCheckHandler(IEnvelopeSignatureValidator validator) : base(validator)
        {
        }

        public override bool Handle(Message message)
        {
            System.Console.WriteLine("Signature Check");
            return base.Handle(message);
        }
    }
}
