using AP.Handlers;
using AP.Messaging;
using System;

namespace AP.Monitoring
{
    public class MonitoredHandler : IHandler
    {
        private IHandler handler;

        public MonitoredHandler(IHandler handler)
        {
            this.handler = handler;
        }

        public void Handle(Message message, IOutput output)
        {
            Console.WriteLine(handler.GetType().Name);
            handler.Handle(message, output);
        }
    }
}
