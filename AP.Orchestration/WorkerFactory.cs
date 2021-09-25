using System.Collections.Generic;

namespace AP.Processing.Async
{
    public class WorkerFactory
    {
        private Dictionary<string, IWorker> map = new Dictionary<string, IWorker>();

        public void Set(string name, IWorker worker)
        {
            map[name] = worker;
        }

        public IWorker Get(string name)
        {
            return map[name];
        }
    }
}
