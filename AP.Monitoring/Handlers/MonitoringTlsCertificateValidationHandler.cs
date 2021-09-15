using AP.Processing;
using AP.Processing.Sync.TlsCertificateValidation;

namespace AP.Monitoring.Handlers
{
    public class MonitoringTlsCertificateValidationHandler : TlsCertificateValidationHandler
    {
        public MonitoringTlsCertificateValidationHandler(
            ICertificateValidator validator, 
            ITlsCertificateValidationErrorFactory errorFactory) 
            : base(validator, errorFactory)
        {
        }

        public override (bool, Message) Handle(Message message)
        {
            System.Console.WriteLine("TLS Check");
            return base.Handle(message);
        }
    }
}
