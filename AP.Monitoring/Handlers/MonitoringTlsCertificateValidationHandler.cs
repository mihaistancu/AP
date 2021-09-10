using AP.Data;
using AP.Processing.Sync;
using AP.Processing.Sync.Handlers.TlsCertificateValidation;

namespace AP.Monitoring.Handlers
{
    public class MonitoringTlsCertificateValidationHandler : TlsCertificateValidationHandler
    {
        public MonitoringTlsCertificateValidationHandler(ICertificateValidator validator) : base(validator)
        {
        }

        public override bool Handle(Message message, IOutput output)
        {
            System.Console.WriteLine("TLS Check");
            return base.Handle(message, output);
        }
    }
}
