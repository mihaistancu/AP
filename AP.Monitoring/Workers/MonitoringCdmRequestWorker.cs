using AP.Data;
using AP.Processing.Async;
using AP.Processing.Async.CDM.Export;
using AP.Processing.Async.CDM.Request;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringCdmRequestWorker: CdmRequestWorker
    {
        public MonitoringCdmRequestWorker(
            IRequestBasedCdmExporter builder, 
            IMessageStorage storage,
            Orchestrator orchestrator) 
            : base(builder, storage, orchestrator)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Cdm Request Export");
            return base.Handle(message);
        }
    }
}
