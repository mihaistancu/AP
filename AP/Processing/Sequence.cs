using System;

namespace AP.Processing
{
    public class Sequence
    {
        private IWorker[] workers;

        public Sequence(params IWorker[] workers)
        {
            this.workers = workers;
        }

        public IWorker GetFirst()
        {
            return workers[0];
        }

        public bool IsLast(IWorker worker)
        {
            return SameType(workers[workers.Length - 1], worker);
        }

        public IWorker GetNext(IWorker worker)
        {
            var index = Array.FindIndex(workers, w => SameType(w, worker));
            return workers[index + 1];
        }

        private bool SameType<T,U>(T a, U b)
        {
            return typeof(T) == typeof(U);
        }
    }
}
