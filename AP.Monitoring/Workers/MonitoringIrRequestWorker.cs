using AP.Processing;
using AP.Processing.Async;
using AP.Processing.Async.IR.Request;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringIrRequestWorker: IrRequestWorker
    {
        public MonitoringIrRequestWorker(
            IRequestBasedIrExporter builder, 
            IMessageStorage storage, 
            Orchestrator orchestrator) 
            : base(builder, storage, orchestrator)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Ir Request Export");
            return base.Handle(message);
        }
    }
}
