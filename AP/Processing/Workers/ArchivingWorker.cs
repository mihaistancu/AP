﻿namespace AP.Processing.Workers
{
    public class ArchivingWorker : IWorker
    {
        public string Step => "Archiving";

        public void Process(WorkerInput input, IWorkflow workflow)
        {
            System.Console.WriteLine("Archiving");

            workflow.Done(this, new WorkerOutput());
        }
    }
}
