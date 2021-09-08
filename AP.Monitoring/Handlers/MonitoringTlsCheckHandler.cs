using AP.Processing.Sync.Handlers;

namespace AP.Monitoring.Handlers
{
    public class MonitoringTlsCheckHandler : TlsCheckHandler
    {
        public override bool Handle(Message message)
        {
            System.Console.WriteLine("TLS Check");
            return base.Handle(message);
        }
    }
}
