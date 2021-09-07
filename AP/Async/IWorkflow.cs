using System.Collections.Generic;

namespace AP.Async
{
    public interface IWorkflow
    {
        void Start(Work work);
        void Next(Work work);
        void Next(Work work, IEnumerable<Message> newMessages);
    }
}
