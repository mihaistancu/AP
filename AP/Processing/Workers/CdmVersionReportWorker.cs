﻿namespace AP.Processing.Workers
{
    public class CdmVersionReportWorker : IWorker
    {
        public void Process(WorkerInput input, IWorkflow workflow)
        {
            System.Console.WriteLine("CdmVersion");

            workflow.Done(this, new WorkerOutput());
        }
    }
}
