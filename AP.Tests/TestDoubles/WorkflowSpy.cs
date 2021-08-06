﻿using AP.Processing;

namespace AP.Tests.TestDoubles
{
    public class WorkflowSpy : IWorkflow
    {
        public bool DoneWasCalled { get; private set; }

        public void Done(IWorker worker, WorkerOutput output)
        {
            DoneWasCalled = true;
        }

        public bool StartWasCalled { get; private set; }

        public void Start(Message message)
        {
            StartWasCalled = true;
        }
    }
}
