using AP.Receiver;

namespace AP.Tests.TestDoubles
{
    public class PipelineSpy: Pipeline
    {
        public bool ProcessWasCalled { get; private set; }

        public override void Process(Message message)
        {
            ProcessWasCalled = true;
        }
    }
}
