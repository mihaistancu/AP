using AP.Instrumentation;
using AP.Orchestration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            using (trace.Start("Broker send", command, SetHeader))
            {
                broker.Send(command);
            }
        }

        private void SetHeader(Command command, string key, object value)
        {
            command.Headers[key] = value;
        }

        public IDisposable Start(Action<Command> handler)
        {
            return broker.Start(command =>
            {
                using (trace.Start("Broker receive", command, GetHeader))
                {
                    handler(command);
                }
            });
        }

        private IEnumerable<string> GetHeader(Command command, string key)
        {
            if (command.Headers.TryGetValue(key, out var value))
            {
                var bytes = value as byte[];
                return new[] { Encoding.UTF8.GetString(bytes) };
            }
            return Enumerable.Empty<string>();
        }
    }
}
