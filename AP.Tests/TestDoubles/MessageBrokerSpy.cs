using AP.Processing;

namespace AP.Tests.TestDoubles
{
    public class MessageBrokerSpy : IMessageBroker
    {
        public WorkerInput InputReceived { get; set; }

        public void Send(WorkerInput input, IWorker worker, IWorkflow workflow)
        {
            
        }
    }
}