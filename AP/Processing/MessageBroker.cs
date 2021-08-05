using System.Collections.Generic;

namespace AP.Processing
{
    public abstract class MessageBroker
    {
        protected Workflow workflow;
        private Dictionary<string, IWorker> workers = new Dictionary<string, IWorker>();

        public void Set(Workflow workflow)
        {
            this.workflow = workflow;
        }

        public virtual void Send(WorkerInput input)
        {
            var worker = workers[input.ProcessingStep];
            worker.Process(input, workflow);
        }

        public void Setup(string step, IWorker worker)
        {
            workers[step] = worker;
        }
    }
}