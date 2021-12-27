using AP.Messages;
using AP.Telemetry;

namespace AP.Workers
{
    public class MonitoredWorker : IWorker
    {
        private ILog log;
        private IWorker worker;

        public MonitoredWorker(ILog log, IWorker worker)
        {
            this.log = log;
            this.worker = worker;
        }

        public bool Handle(Message message)
        {
            log.Debug(worker.GetType().Name);
            return worker.Handle(message);
        }
    }
}
