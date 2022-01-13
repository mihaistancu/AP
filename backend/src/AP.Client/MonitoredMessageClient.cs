using AP.Gateways;
using AP.Instrumentation;
using AP.Messages;

namespace AP.Client
{
    public class MonitoredMessageClient : IMessageClient
    {
        private ITrace trace;
        private IMessageClient client;

        public MonitoredMessageClient(ITrace trace, IMessageClient client)
        {
            this.trace = trace;
            this.client = client;
        }

        public void Send(string url, Message message)
        {
            using (trace.Start("Send to URL"))
            {
                client.Send(url, message);
            }
        }
    }
}
