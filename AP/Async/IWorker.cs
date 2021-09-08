using System.Collections.Generic;

namespace AP.Async
{
    public interface IWorker
    {
        Message[] Handle(Message message);
    }
}
