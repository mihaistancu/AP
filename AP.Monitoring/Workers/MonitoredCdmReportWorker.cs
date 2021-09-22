using AP.Processing;
using AP.Processing.Async.Synchronization;
using AP.Processing.Async.Synchronization.CDM.Report;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoredCdmReportWorker<T>: CdmReportWorker<T> where T: IGateway
    {
        public MonitoredCdmReportWorker(
            ICdmReporter reporter, 
            T gateway) 
            : base(reporter, gateway)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Cdm Version Report");
            return base.Handle(message);
        }
    }
}
