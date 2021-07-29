namespace AP.Tests
{
    public class MockMessageBroker: MessageBroker
    {
        public MockMessageBroker(IPipeline pipeline)
        {
            this.pipeline = pipeline;
        }
    }
}
