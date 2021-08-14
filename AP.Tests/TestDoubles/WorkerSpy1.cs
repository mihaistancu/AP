﻿using AP.Processing;

namespace AP.Tests.TestDoubles
{
    public class WorkerSpy1 : IWorker
    {
        public bool ProcessWasCalled { get; private set; }

        public string Step { get; set; }

        public void Process(Work input, IWorkflow workflow)
        {
            ProcessWasCalled = true;
        }
    }
}
