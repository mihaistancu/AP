using AP.Data;
using AP.Processing.Async;
using AP.Processing.Async.Workers.IR.Export;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringIrRequestExportWorker: IrRequestExportWorker
    {
        public MonitoringIrRequestExportWorker(
            IIrExportBuilder builder, 
            IMessageStorage storage,
            Orchestrator orchestrator) 
            : base(builder, storage, orchestrator)
        {
        }

        public override void Handle(Message message)
        {
            Console.WriteLine("Ir Request Export");
            base.Handle(message);
        }
    }
}
