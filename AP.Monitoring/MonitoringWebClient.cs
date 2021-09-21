using AP.Messaging.Client;
using AP.Processing;
using System;

namespace AP.Monitoring
{
    public class MonitoringWebClient: MessagingClient
    {
        public override void Send(string url, Message message)
        {
            Console.WriteLine("Push");
            base.Send(url, message);
        }
    }
}
