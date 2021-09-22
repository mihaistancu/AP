﻿using AP.Processing;
using AP.Processing.Async.Forwarding;
using AP.Processing.Async.Synchronization;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoredForwardingWorker<T> : ForwardingWorker<T> where T: IGateway
    {
        public MonitoredForwardingWorker(T gateway) : base(gateway)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Forwarding");
            return base.Handle(message);
        }
    }
}