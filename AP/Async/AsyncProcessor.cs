namespace AP.Async
{
    public class AsyncProcessor : IProcessor
    {
        private readonly WorkflowFactory factory;
        private readonly MessageBroker broker;

        public AsyncProcessor(WorkflowFactory factory, MessageBroker broker)
        {
            this.factory = factory;
            this.broker = broker;
        }

        public void Process(Message message)
        {
            var workflow = factory.Get(message.SedType);
            var worker = workflow.GetFirst();
            broker.Send(worker, workflow, new[] { message });
        }
    }
}
