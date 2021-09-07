using AP.Async;
using System.Collections.Generic;

namespace AP.Tests.TestDoubles
{
    public class MessageBrokerSpy : MessageBroker
    {
        public MessageBrokerSpy(ExceptionHandler exceptionHandler): base(exceptionHandler)
        {
        }

        public IWorker CalledWorker { get; private set; }
        
        public override void Send(Context context, IEnumerable<Message> messages)
        {
            CalledWorker = context.Worker;
        }
    }
}