using AP.Processing;

namespace AP.Tests.TestDoubles
{
    public class WorkerSpy2 : Worker
    {
        public bool DoWasCalled { get; private set; }
        
        public override void Do(Work work)
        {
            DoWasCalled = true;
        }
    }
}
