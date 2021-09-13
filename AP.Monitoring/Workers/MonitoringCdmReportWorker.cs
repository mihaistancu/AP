using AP.Data;
using AP.Processing.Async;
using AP.Processing.Async.CDM.Report;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringCdmReportWorker: CdmReportWorker
    {
        public MonitoringCdmReportWorker(
            ICdmReportFactory builder, 
            IMessageStorage storage, 
            Orchestrator orchestrator) 
            : base(builder, storage, orchestrator)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Cdm Version Report");
            return base.Handle(message);
        }
    }
}
