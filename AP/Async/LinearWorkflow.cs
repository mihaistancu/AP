using System.Collections.Generic;

namespace AP.Async
{
    public class LinearWorkflow : IWorkflow
    {
        private readonly IMessageBroker broker;
        private WorkerSequence sequence;

        public LinearWorkflow(IMessageBroker broker, params IWorker[] workers)
        {
            sequence = new WorkerSequence(workers);
            this.broker = broker;
        }

        public void Start(Context context, Message message)
        {
            context.Worker = sequence.GetFirst();
            broker.Send(context, new[] { message });
        }
        
        public void Next(Context context, IEnumerable<Message> messages)
        {
            if (!sequence.IsLast(context.Worker))
            {
                context.Worker = sequence.GetNext(context.Worker);
                broker.Send(context, messages);
            }
        }
    }
}