﻿using AP.Processing;
using AP.Routing;

namespace AP.Inbox
{
    public class Queue : IQueue
    {
        public virtual void Enqueue(string channel, params Message[] messages)
        {
            
        }
    }
}
