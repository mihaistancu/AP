using AP.Instrumentation;
using AP.Messages;

namespace AP.Handlers
{
    public class MonitoredHandler : IHandler
    {
        private ILog log;
        private IHandler handler;

        public MonitoredHandler(ILog log, IHandler handler)
        {
            this.log = log;
            this.handler = handler;
        }

        public void Handle(Message message, IOutput output)
        {
            log.Debug(handler.GetType().Name);
            handler.Handle(message, output);
        }
    }
}
