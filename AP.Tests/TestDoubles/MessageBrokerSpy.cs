using AP.Processing;

namespace AP.Tests.TestDoubles
{
    public class MessageBrokerSpy : IMessageBroker
    {
        public IWorker CalledWorker { get; private set; }

        public void Send(WorkerInput input, IWorker worker, IWorkflow workflow)
        {
            CalledWorker = worker;
        }
    }
}