﻿namespace AP.Processing.Workers
{
    public class IrSubscriptionExportWorker : Worker
    {
        public override void Do(Work work)
        {
            System.Console.WriteLine("IrSubscriptionExport");

            work.Workflow.Done(work);
        }
    }
}
