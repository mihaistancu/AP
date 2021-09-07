﻿namespace AP.Async.Workers.IR.Export
{
    public class IrRequestExportWorker : Worker
    {
        private IIrExportBuilder builder;

        public IrRequestExportWorker(IIrExportBuilder builder)
        {
            this.builder = builder;
        }

        public override void Do(Work work)
        {
            System.Console.WriteLine("IrRequestExport");

            builder.UseRequest(work.Message);
            var newMessages = builder.Build();

            work.Workflow.Next(work, newMessages);
        }
    }
}
