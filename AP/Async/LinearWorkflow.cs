using System.Collections.Generic;

namespace AP.Async
{
    public class LinearWorkflow : IWorkflow
    {
        private readonly IMessageBroker broker;
        private WorkerSequence sequence;

        public LinearWorkflow(IMessageBroker broker, params Worker[] workers)
        {
            sequence = new WorkerSequence(workers);
            this.broker = broker;
        }

        public void Start(Work work)
        {
            work.Worker = sequence.GetFirst();
            broker.Send(work);
        }

        public void Next(Work work)
        {
            if (!sequence.IsLast(work.Worker))
            {
                work.Worker = sequence.GetNext(work.Worker);
                broker.Send(work);
            }
        }

        public void Next(Work work, IEnumerable<Message> newMessages)
        {       
            work.Worker = sequence.GetNext(work.Worker);
            broker.Send(work, newMessages);
        }
    }
}