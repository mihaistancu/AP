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

        public string GetFirst()
        {
            return workers[0].Step;
        }

        public bool IsLast(string step)
        {
            return workers[workers.Length - 1].Step == step;
        }

        public string GetNext(string step)
        {
            var index = Array.FindIndex(workers, w => w.Step == step);
            return workers[index + 1].Step;
        }
    }
}
