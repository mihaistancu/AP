namespace AP
{
    public abstract class Pipeline
    {
        MessageBroker broker;

        public void Set(MessageBroker broker)
        {
            this.broker = broker;
        }

        public abstract ProcessingRequest GetNext(ProcessingRequest request);

        public virtual void Done(ProcessingRequest request)
        {
            var next = GetNext(request);
            broker.Send(next);
        }
    }
}