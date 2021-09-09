using AP.Data;
using AP.Processing.Sync.Handlers.Auth;

namespace AP.Monitoring.Handlers
{
    public class MonitoringTlsCheckHandler : TlsCertificateCheckHandler
    {
        public MonitoringTlsCheckHandler(ICertificateValidator validator) : base(validator)
        {
        }

        public override bool Handle(Message message)
        {
            System.Console.WriteLine("TLS Check");
            return base.Handle(message);
        }
    }
}
