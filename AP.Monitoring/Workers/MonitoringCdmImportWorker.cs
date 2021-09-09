using AP.Data;
using AP.Processing.Async.Workers.CDM.Import;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringCdmImportWorker: CdmImportWorker
    {
        public MonitoringCdmImportWorker(ICdmImporter parser) : base(parser)
        {
        }

        public override Message[] Handle(Message message)
        {
            Console.WriteLine("Cdm Import");
            return base.Handle(message);
        }
    }
}
