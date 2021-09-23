using AP.Middleware.RabbitMQ;
using AP.Processing.Async;
using System;

namespace AP.Host.Console
{
    public class Workers : IWorkers
    {
        private Store store;

        public Workers(Store store)
        {
            this.store = store;
        }

        public IWorker Worker(string workerId)
        {
            return store.Get<IWorker>(Type.GetType(workerId));
        }

        public string Id(IWorker worker)
        {
            return worker.GetType().AssemblyQualifiedName;
        }
    }
}
