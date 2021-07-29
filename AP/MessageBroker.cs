using System.Collections.Generic;

namespace AP
{
    public abstract class MessageBroker
    {
        private Dictionary<string, IHandler> handlers = new Dictionary<string, IHandler>();

        public void Send(ProcessingRequest request)
        {
            var handler = handlers[request.Step];
            handler.Handle(request);
        }

        public void Setup(string step, IHandler handler)
        {
            handlers[step] = handler;
        }
    }
}