using System.Collections.Generic;

namespace AP.Async
{
    public interface IWorkflow
    {
        void Start(Context context, Message message);
        void Next(Context context, IEnumerable<Message> messages);
    }
}
