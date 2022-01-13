using AP.Instrumentation;
using AP.Messages;

namespace AP.Workers
{
    public class MonitoredWorker : IWorker
    {
        private ITrace trace;
        private IWorker worker;

        public MonitoredWorker(ITrace trace, IWorker worker)
        {
            this.trace = trace;
            this.worker = worker;
        }

        public bool Handle(Message message)
        {
            using (trace.Start(worker.GetType().Name))
            {
                return worker.Handle(message);
            }
        }
    }
}
