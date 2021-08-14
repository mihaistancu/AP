namespace AP.Processing
{
    public class LinearWorkflow: IWorkflow
    {
        private WorkerSequence sequence;

        public LinearWorkflow(WorkerSequence sequence)
        {
            this.sequence = sequence;
        }

        public void Done(Work work)
        {
            if (!sequence.IsLast(work.Worker))
            {
                work.Worker = sequence.GetNext(work.Worker);
                Context.MessageBroker.Send(work);
            }
        }

        public void Start(Message message)
        {
            var input = new Work
            {
                Worker = sequence.GetFirst(),
                Workflow = this
            };
            Context.MessageBroker.Send(input);
        }
    }
}