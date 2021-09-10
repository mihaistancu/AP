using AP.Data;
using AP.Processing.Async;
using AP.Processing.Async.Workers.CDM.Report;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringCdmVersionReportWorker: CdmVersionReportWorker
    {
        public MonitoringCdmVersionReportWorker(
            ICdmReportBuilder builder, 
            IMessageStorage storage,
            Orchestrator orchestrator) 
            : base(builder, storage, orchestrator)
        {
        }

        public override void Handle(Message message)
        {
            Console.WriteLine("Cdm Version Report");
            base.Handle(message);
        }
    }
}
