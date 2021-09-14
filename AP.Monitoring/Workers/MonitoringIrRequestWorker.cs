﻿using AP.Processing;
using AP.Processing.Async;
using AP.Processing.Async.IR.Request;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringIrRequestWorker: IrRequestWorker
    {
        public MonitoringIrRequestWorker(IIrProvider publisher) : base(publisher)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Ir Request");
            return base.Handle(message);
        }
    }
}
