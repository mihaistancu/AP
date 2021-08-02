using System.Collections.Generic;

namespace AP
{
    public abstract class MessageBroker
    {
        protected Workflow workflow;
        private Dictionary<string, IHandler> handlers = new Dictionary<string, IHandler>();

        public void Set(Workflow workflow)
        {
            this.workflow = workflow;
        }

        public virtual void Send(ProcessingRequest request)
        {
            var handler = handlers[request.Step];
            handler.Handle(request.Message);
            workflow.Done(request);
        }

        public void Setup(string step, IHandler handler)
        {
            handlers[step] = handler;
        }
    }
}