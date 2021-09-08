using AP.Processing.Sync.Handlers;

namespace AP.Monitoring.Handlers
{
    public class MonitoringSignatureCheckHandler : SignatureCheckHandler
    {
        public override bool Handle(Message message)
        {
            System.Console.WriteLine("Signature Check");
            return base.Handle(message);
        }
    }
}
