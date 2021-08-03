using AP.Receiver;

namespace AP.Tests.TestDoubles
{
    public class PipelineSpy: Pipeline
    {
        public bool WasCalled { get; private set; }

        public override void Process(Message message)
        {
            WasCalled = true;
        }
    }
}
