using AP.Data;
using AP.Processing.Async.Workers.CDM.Export;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringCdmRequestExportWorker: CdmRequestExportWorker
    {
        public MonitoringCdmRequestExportWorker(ICdmExportBuilder builder, IMessageStorage storage) : base(builder, storage)
        {
        }

        public override Message[] Handle(Message message)
        {
            Console.WriteLine("Cdm Request Export");
            return base.Handle(message);
        }
    }
}
