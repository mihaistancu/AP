﻿using AP.Processing;
using AP.Processing.Async.CDM.Report;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringCdmReportWorker<T>: CdmReportWorker<T> where T: IGateway
    {
        public MonitoringCdmReportWorker(
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
