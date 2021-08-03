namespace AP
{
    public abstract class Workflow
    {
        MessageBroker broker;

        public void Set(MessageBroker broker)
        {
            this.broker = broker;
        }

        public abstract WorkerInput GetNext(WorkerOutput output);

        public virtual void Done(WorkerOutput output)
        {
            var input = GetNext(output);
            broker.Send(input);
        }
    }
}