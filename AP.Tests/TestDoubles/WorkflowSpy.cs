using AP.Async;
using System.Collections.Generic;

namespace AP.Tests.TestDoubles
{
    public class WorkflowSpy : IWorkflow
    {
        public bool NextWasCalled { get; private set; }

        public bool StartWasCalled { get; private set; }

        public void Start(Message message)
        {
            StartWasCalled = true;
        }

        public void Next(Context context, IEnumerable<Message> messages)
        {
            NextWasCalled = true;
        }
    }
}
