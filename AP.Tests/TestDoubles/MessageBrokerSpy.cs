using AP.Processing;

namespace AP.Tests.TestDoubles
{
    public class MessageBrokerSpy : IMessageBroker
    {
        public IWorker CalledWorker { get; private set; }

        public void Send(Work input)
        {
            CalledWorker = input.Worker;
        }

        public Message SentMessage { get; set; }

        public void Send(Message message)
        {
            SentMessage = message;
        }
    }
}