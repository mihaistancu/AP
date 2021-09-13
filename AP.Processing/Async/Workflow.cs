﻿using System;

namespace AP.Processing.Async
{
    public class Workflow
    {
        private IWorker[] workers;

        public Workflow(params IWorker[] workers)
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
            return last == worker;
        }

        public IWorker GetNext(IWorker worker)
        {
            int index = Array.FindIndex(workers, w => w == worker);
            return workers[index + 1];
        }
    }
}
