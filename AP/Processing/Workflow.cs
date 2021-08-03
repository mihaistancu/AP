using AP.Receiver;

namespace AP.Processing
{
    public abstract class Workflow
    {
        MessageBroker broker;

        public void Set(MessageBroker broker)
        {
            this.broker = broker;
        }

        public abstract WorkerInput GetFirst(Message message);
        public abstract WorkerInput GetNext(WorkerOutput output);

        public virtual void Done(WorkerOutput output)
        {
            var input = GetNext(output);
            broker.Send(input);
        }

        public virtual void Start(Message message)
        {
            var input = GetFirst(message);
            broker.Send(input);
        }
    }
}