using System.Collections.Generic;

namespace AP.Async
{
    public interface IMessageBroker
    {
        void Send(Work input);

        void Send(Work input, IEnumerable<Message> batch);
    }
}