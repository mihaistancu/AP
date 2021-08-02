using System.Collections.Generic;

namespace AP
{
    public class Pipeline
    {
        private List<IHandler> handlers = new List<IHandler>();

        public void Add(IHandler handler)
        {
            handlers.Add(handler);
        }

        public void Process(Message message)
        {
            foreach(var handler in handlers)
            {
                handler.Handle(message);
            }
        }
    }
}