namespace AP.Tests.TestDoubles
{
    public class HandlerSpy : IHandler
    {
        public bool WasCalled { get; private set; }

        public void Handle(ProcessingRequest request)
        {
            WasCalled = true;
        }
    }
}