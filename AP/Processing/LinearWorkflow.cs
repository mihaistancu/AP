namespace AP.Processing
{
    public class LinearWorkflow: IWorkflow
    {
        private readonly IMessageBroker broker;
        private WorkerSequence sequence;

        public LinearWorkflow(IMessageBroker broker, params IWorker[] workers)
        {
            this.sequence = new WorkerSequence(workers);
            this.broker = broker;
        }

        public void Done(Work work)
        {
            if (!sequence.IsLast(work.Worker))
            {
                work.Worker = sequence.GetNext(work.Worker);
                broker.Send(work);
            }
        }

        public void Start(Message message)
        {
            var work = new Work
            {
                Worker = sequence.GetFirst(),
                Workflow = this
            };
            broker.Send(work);
        }
    }
}