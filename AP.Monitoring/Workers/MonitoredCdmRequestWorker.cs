using AP.Processing;
using AP.Processing.Async.Synchronization.CDM.Request;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoredCdmRequestWorker: CdmRequestWorker
    {
        public MonitoredCdmRequestWorker(ICdmProvider responder) : base(responder)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Cdm Request");
            return base.Handle(message);
        }
    }
}
