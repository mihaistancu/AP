using AP.Instrumentation;
using AP.Messages;

namespace AP.Handlers
{
    public class MonitoredHandler : IHandler
    {
        private ITrace trace;
        private IHandler handler;

        public MonitoredHandler(ITrace trace, IHandler handler)
        {
            this.trace = trace;
            this.handler = handler;
        }

        public void Handle(Message message, IOutput output)
        {
            using (trace.Start(handler.GetType().Name))
            {
                handler.Handle(message, output);
            }
        }
    }
}
