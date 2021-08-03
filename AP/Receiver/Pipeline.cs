using System.Collections.Generic;

namespace AP.Receiver
{
    public class Pipeline
    {
        private List<IHandler> handlers = new List<IHandler>();

        public void Add(IHandler handler)
        {
            handlers.Add(handler);
        }

        public virtual void Process(Message message)
        {
            foreach (var handler in handlers)
            {
                bool canContinue = handler.Handle(message);

                if (!canContinue) break;
            }
        }
    }
}