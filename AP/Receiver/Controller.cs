using AP.Processing;

namespace AP.Receiver
{
    public class Controller
    {
        private Pipeline pipeline;
        private Workflow workflow;

        public Controller(Pipeline pipeline, Workflow workflow)
        {
            this.pipeline = pipeline;
            this.workflow = workflow;
        }

        public void Handle(Message message)
        {
            pipeline.Process(message);
            workflow.Start(message);
        }
    }
}