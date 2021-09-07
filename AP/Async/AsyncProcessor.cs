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

            var context = new Context
            {   
                Worker = workflow.GetFirst(),
                Workflow = workflow
            };
            broker.Send(context, new[] { message });
        }
    }
}
