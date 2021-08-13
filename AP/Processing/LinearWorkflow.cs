namespace AP.Processing
{
    public class LinearWorkflow: IWorkflow
    {
        private WorkerSequence sequence;

        public LinearWorkflow(WorkerSequence sequence)
        {
            this.sequence = sequence;
        }

        public void Done(IWorker current, WorkerOutput output)
        {
            if (!sequence.IsLast(current))
            {
                var input = new WorkerInput();
                var next = sequence.GetNext(current);
                Context.MessageBroker.Send(input, next, this);
            }
        }

        public void Start(Message message)
        {
            var input = new WorkerInput();
            var worker = sequence.GetFirst();
            Context.MessageBroker.Send(input, worker, this);
        }
    }
}