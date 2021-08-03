using AP.Processing;

namespace AP.Tests.TestDoubles
{
    public class MessageBrokerSpy : MessageBroker
    {
        public WorkerInput Received { get; set; }

        public override void Send(WorkerInput input)
        {
            Received = input;
        }
    }
}