using AP.Processing;
using AP.Processing.Async;
using AP.Processing.Async.Synchronization.IR.Request;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoredIrRequestWorker: IrRequestWorker
    {
        public MonitoredIrRequestWorker(IIrProvider publisher) : base(publisher)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Ir Request");
            return base.Handle(message);
        }
    }
}
