namespace AP.Processing
{
    public interface IMessageBroker
    {
        void Send(Message message);
        void Send(WorkerInput input, IWorker worker, IWorkflow workflow);
    }
}