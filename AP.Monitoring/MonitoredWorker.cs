using AP.Processing;
using AP.Processing.Async;
using System;

namespace AP.Monitoring
{
    public class MonitoredWorker : IWorker
    {
        private IWorker worker;

        public MonitoredWorker(IWorker worker)
        {
            this.worker = worker;
        }

        public bool Handle(Message message)
        {
            Console.WriteLine(worker.GetType().Name);
            return worker.Handle(message);
        }
    }
}
