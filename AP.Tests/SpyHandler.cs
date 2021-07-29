namespace AP.Tests
{
    public class SpyHandler: IHandler
    {
        public bool WasCalled { get; private set; }

        public void Handle(ProcessingRequest request)
        {
            WasCalled = true;    
        }
    }
}