using AP.Processing;
using AP.Processing.Sync;
using AP.Processing.Sync.TlsCertificateValidation;

namespace AP.Monitoring.Handlers
{
    public class MonitoredTlsCertificateValidationHandler : TlsCertificateValidationHandler
    {
        public MonitoredTlsCertificateValidationHandler(
            ICertificateValidator validator, 
            ITlsCertificateValidationErrorFactory errorFactory) 
            : base(validator, errorFactory)
        {
        }

        public override void Handle(Message message, IOutput output)
        {
            System.Console.WriteLine("TLS Check");
            base.Handle(message, output);
        }
    }
}
