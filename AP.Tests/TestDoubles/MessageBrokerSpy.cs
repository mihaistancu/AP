using AP.Async;
using System.Collections.Generic;

namespace AP.Tests.TestDoubles
{
    public class MessageBrokerSpy : IMessageBroker
    {
        public IWorker CalledWorker { get; private set; }
        
        public void Send(Context context, IEnumerable<Message> messages)
        {
            CalledWorker = context.Worker;
        }
    }
}