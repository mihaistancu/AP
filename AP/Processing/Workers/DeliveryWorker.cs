using System;

namespace AP.Processing.Workers
{
    public class DeliveryWorker : Worker
    {
        public override void Do(Work work)
        {
            System.Console.WriteLine("Delivery");

            work.Workflow.Done(work);
        }

        public override void Handle(Exception exception, Work work)
        {
            
        }
    }
}
