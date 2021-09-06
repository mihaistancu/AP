using System;

namespace AP.Processing
{
    public class WorkerSequence
    {
        private Worker[] workers;

        public WorkerSequence(params Worker[] workers)
        {
            this.workers = workers;
        }

        public Worker GetFirst()
        {
            return workers[0];
        }

        public bool IsLast(Worker worker)
        {
            Worker last = workers[workers.Length - 1];
            return last == worker;
        }

        public Worker GetNext(Worker worker)
        {
            int index = Array.FindIndex(workers, w => w.GetType() == worker.GetType());
            return workers[index + 1];
        }
    }
}
