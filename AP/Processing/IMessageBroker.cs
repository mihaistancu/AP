using System.Collections.Generic;

namespace AP.Processing
{
    public interface IMessageBroker
    {
        void Send(WorkerInput input, IWorker worker, IWorkflow workflow);
    }
}