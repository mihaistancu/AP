namespace AP.Tests
{
    public class SpyMessageBroker: MessageBroker
    {
        public bool WasCalled { get; set; }

        public override void Send(ProcessingRequest request)
        {
            WasCalled = true;    
        }
    }
}