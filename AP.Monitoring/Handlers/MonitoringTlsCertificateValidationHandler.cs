using AP.Data;
using AP.Processing.Sync.Handlers.TlsCertificateValidation;

namespace AP.Monitoring.Handlers
{
    public class MonitoringTlsCertificateValidationHandler : TlsCertificateValidationHandler
    {
        public MonitoringTlsCertificateValidationHandler(ICertificateValidator validator) : base(validator)
        {
        }

        public override bool Handle(Message message)
        {
            System.Console.WriteLine("TLS Check");
            return base.Handle(message);
        }
    }
}
