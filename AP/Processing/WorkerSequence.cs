using System;

namespace AP.Processing
{
    public class WorkerSequence
    {
        private IWorker[] workers;

        public WorkerSequence(params IWorker[] workers)
        {
            this.workers = workers;
        }

        public IWorker GetFirst()
        {
            return workers[0];
        }

        public bool IsLast(IWorker worker)
        {
            IWorker last = workers[workers.Length - 1];
            return SameType(last, worker);
        }

        public IWorker GetNext(IWorker worker)
        {
            int index = Array.FindIndex(workers, w => SameType(w, worker));
            return workers[index + 1];
        }

        private bool SameType<T,U>(T a, U b)
        {
            return typeof(T) == typeof(U);
        }
    }
}
