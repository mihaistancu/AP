using AP.Data;
using AP.Processing.Async;
using AP.Processing.Async.Workers.CDM.Export;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringCdmRequestExportWorker: CdmRequestExportWorker
    {
        public MonitoringCdmRequestExportWorker(
            ICdmExportBuilder builder, 
            IMessageStorage storage,
            Orchestrator orchestrator) 
            : base(builder, storage, orchestrator)
        {
        }

        public override void Handle(Message message)
        {
            Console.WriteLine("Cdm Request Export");
            base.Handle(message);
        }
    }
}
