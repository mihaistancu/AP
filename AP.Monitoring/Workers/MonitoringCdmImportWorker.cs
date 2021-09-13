using AP.Data;
using AP.Processing.Async.CDM.Import;
using AP.Processing.Async.Workers.CDM.Import;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringCdmImportWorker: CdmImportWorker
    {
        public MonitoringCdmImportWorker(ICdmImporter parser) : base(parser)
        {
        }

        public override void Handle(Message message)
        {
            Console.WriteLine("Cdm Import");
            base.Handle(message);
        }
    }
}
