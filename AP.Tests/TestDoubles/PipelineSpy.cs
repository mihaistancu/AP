using AP.Sync;
using System;

namespace AP.Tests.TestDoubles
{
    public class PipelineSpy: Pipeline
    {
        public bool ProcessWasCalled { get; private set; }

        public bool ThrowException { get; set; }

        public override void Process(Message message)
        {
            if (ThrowException)
            {
                throw new Exception();
            }
            ProcessWasCalled = true;
        }
    }
}
