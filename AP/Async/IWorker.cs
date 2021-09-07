using System.Collections.Generic;

namespace AP.Async
{
    public interface IWorker
    {
        IEnumerable<Message> Handle(Message message);
    }
}
