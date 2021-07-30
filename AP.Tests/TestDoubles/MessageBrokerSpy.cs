namespace AP.Tests.TestDoubles
{
    public class MessageBrokerSpy : MessageBroker
    {
        public ProcessingRequest Received { get; set; }

        public override void Send(ProcessingRequest request)
        {
            Received = request;
        }
    }
}