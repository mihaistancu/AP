﻿using AP.Processing;
using AP.Web.Client;
using System;

namespace AP.Monitoring
{
    public class MonitoringWebClient: WebClient
    {
        public override void Send(string url, params Message[] messages)
        {
            Console.WriteLine("Push");
            base.Send(url, messages);
        }
    }
}