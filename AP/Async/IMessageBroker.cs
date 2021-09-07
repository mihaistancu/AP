using System.Collections.Generic;

namespace AP.Async
{
    public interface IMessageBroker
    {
        void Send(Context input, IEnumerable<Message> messages);
    }
}