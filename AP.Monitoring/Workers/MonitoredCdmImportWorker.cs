using AP.Processing;
using AP.Processing.Async.Synchronization.CDM.Import;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoredCdmImportWorker: CdmImportWorker
    {
        public MonitoredCdmImportWorker(ICdmImporter parser) : base(parser)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Cdm Import");
            return base.Handle(message);
        }
    }
}
