using AP.Data;
using AP.Processing.Async.Workers.IR.Import;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringIrImportWorker: IrImportWorker
    {
        public MonitoringIrImportWorker(IIrImporter importer) : base(importer)
        {
        }

        public override Message[] Handle(Message message)
        {
            Console.WriteLine("Ir Import");
            return base.Handle(message);
        }
    }
}
