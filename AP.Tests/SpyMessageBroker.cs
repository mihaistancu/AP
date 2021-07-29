namespace AP.Tests
{
    public class SpyMessageBroker: MessageBroker
    {
        public ProcessingRequest Received { get; set; }

        public override void Send(ProcessingRequest request)
        {
            Received = request;    
        }
    }
}