using System.Collections.Generic;

namespace AP
{
    public abstract class MessageBroker
    {
        protected Pipeline pipeline;
        private Dictionary<string, IHandler> handlers = new Dictionary<string, IHandler>();

        public void Set(Pipeline pipeline)
        {
            this.pipeline = pipeline;
        }

        public virtual void Send(ProcessingRequest request)
        {
            var handler = handlers[request.Step];
            handler.Handle(request);
            pipeline.Done(request);
        }

        public void Setup(string step, IHandler handler)
        {
            handlers[step] = handler;
        }
    }
}