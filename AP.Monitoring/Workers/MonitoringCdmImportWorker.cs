using AP.Data;
using AP.Processing.Async.Workers.CDM;
using AP.Processing.Async.Workers.CDM.Import;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringCdmImportWorker: CdmImportWorker
    {
        public MonitoringCdmImportWorker(ICdmParser parser, ICdmStorage storage) : base(parser, storage)
        {
        }

        public override Message[] Handle(Message message)
        {
            Console.WriteLine("Cdm Import");
            return base.Handle(message);
        }
    }
}
