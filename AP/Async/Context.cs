using System;

namespace AP.Async
{
    public class Context
    {
        public IWorker Worker { get; set; }
        public Workflow Workflow { get; set; }        
    }
}
