using AP.Processing;
using AP.Processing.Async.CDM.Request;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringCdmRequestWorker: CdmRequestWorker
    {
        public MonitoringCdmRequestWorker(ICdmRequestResponder responder) : base(responder)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Cdm Request Export");
            return base.Handle(message);
        }
    }
}
