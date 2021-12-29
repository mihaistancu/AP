using AP.Instrumentation;
using AP.Orchestration;
using System;

namespace AP.Broker
{
    public class MonitoredBroker : IBroker
    {
        private ITrace trace;
        private IBroker broker;

        public MonitoredBroker(ITrace trace, IBroker broker)
        {
            this.trace = trace;
            this.broker = broker;
        }

        public void Send(Command command)
        {
            using (trace.Start("Broker send"))
            {
                broker.Send(command);
            }
        }

        public IDisposable Start(Action<Command> handler)
        {
            return broker.Start(command =>
            {
                using (trace.Start("Broker receive"))
                {
                    handler(command);
                }   
            });
        }
    }
}
