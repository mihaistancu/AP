using System;

namespace AP.Orchestration
{
    public class Workflow
    {
        private string[] workers;

        public Workflow(params string[] workers)
        {
            this.workers = workers;
        }

        public string GetFirst()
        {
            return workers[0];
        }

        public bool IsLast(string worker)
        {
            string last = workers[workers.Length - 1];
            return last == worker;
        }

        public string GetNext(string worker)
        {
            int index = Array.FindIndex(workers, w => w == worker);
            return workers[index + 1];
        }
    }
}
