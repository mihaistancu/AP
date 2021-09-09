using AP.Data;
using AP.Processing.Async.Workers.IR;
using AP.Processing.Async.Workers.IR.Import;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringIrImportWorker: IrImportWorker
    {
        public MonitoringIrImportWorker(IIrParser parser, IIrStorage storage) : base(parser, storage)
        {
        }

        public override Message[] Handle(Message message)
        {
            Console.WriteLine("Ir Import");
            return base.Handle(message);
        }
    }
}
