﻿namespace AP.Processing.Workers
{
    public class DeliveryWorker : IWorker
    {
        public string Step => "Delivery";

        public void Process(WorkerInput input, IWorkflow workflow)
        {
            System.Console.WriteLine("Delivery");

            workflow.Done(this, new WorkerOutput());
        }
    }
}