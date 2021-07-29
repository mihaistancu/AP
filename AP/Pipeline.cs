namespace AP
{
    public class Pipeline: IPipeline
    {
        MessageBroker broker;

        public void Set(MessageBroker broker)
        {
            this.broker = broker;
        }

        public void Done(ProcessingRequest request)
        {
            broker.Send(request);
        }
    }
}