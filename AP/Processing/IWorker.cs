﻿namespace AP.Processing
{
    public interface IWorker
    {
        string Step { get; }
        void Process(WorkerInput input, IWorkflow workflow);
    }
}
