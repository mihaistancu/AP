using System.Collections.Generic;
using System.Linq;

namespace AP.Processing.Async
{
    public class WorkerMap
    {
        private Dictionary<string, IWorker> map = new Dictionary<string, IWorker>();

        public IWorker Add(IWorker worker, string name)
        {
            map[name] = worker;
            return worker;
        }

        public IWorker Worker(string name)
        {
            return map[name];
        }

        public string Name(IWorker worker)
        {
            return map.Keys.Single(k => map[k] == worker);
        }
    }
}
