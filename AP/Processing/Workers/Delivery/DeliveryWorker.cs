﻿using System;

namespace AP.Processing.Workers.Delivery
{
    public class DeliveryWorker : Worker
    {
        public override void Do(Work work)
        {
            Console.WriteLine("Delivery");

            work.Workflow.Done(work);
        }

        public override void Handle(Exception exception, Work work)
        {

        }
    }
}
