using AP.Gateways;
using AP.Messages;
using AP.Telemetry;

namespace AP.Client
{
    public class MonitoredMessageClient : IMessageClient
    {
        private ILog log;
        private IMessageClient client;

        public MonitoredMessageClient(ILog log, IMessageClient client)
        {
            this.log = log;
            this.client = client;
        }

        public void Send(string url, Message message)
        {
            log.Debug("Push");
            client.Send(url, message);
        }
    }
}
