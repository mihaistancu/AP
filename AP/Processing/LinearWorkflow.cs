namespace AP.Processing
{
    public class LinearWorkflow: IWorkflow
    {
        private IMessageBroker broker;
        private WorkerSequence sequence;

        public LinearWorkflow(IMessageBroker broker, WorkerSequence sequence)
        {
            this.broker = broker;
            this.sequence = sequence;
        }

        public void Done(IWorker current, WorkerOutput output)
        {
            if (!sequence.IsLast(current))
            {
                var input = new WorkerInput();
                var next = sequence.GetNext(current);
                broker.Send(input, next, this);
            }
        }

        public void Start(Message message)
        {
            var input = new WorkerInput();
            var worker = sequence.GetFirst();
            broker.Send(input, worker, this);
        }
    }
}