using AP.Gateways.Institution;
using AP.Processing;
using System;

namespace AP.Monitoring
{
    public class MonitoredMessageClient: IMessageClient
    {
        private IMessageClient client;

        public MonitoredMessageClient(IMessageClient client)
        {
            this.client = client;
        }

        public void Send(string url, Message message)
        {
            Console.WriteLine("Push");
            client.Send(url, message);
        }
    }
}
