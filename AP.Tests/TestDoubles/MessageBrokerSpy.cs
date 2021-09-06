using AP.Async;

namespace AP.Tests.TestDoubles
{
    public class MessageBrokerSpy : IMessageBroker
    {
        public Worker CalledWorker { get; private set; }

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