using AP.Processing;

namespace AP.Receiver
{
    public class Controller
    {
        private Pipeline pipeline;
        private Workflow workflow;
        private IResponder responder;

        public Controller(Pipeline pipeline, Workflow workflow, IResponder responder)
        {
            this.pipeline = pipeline;
            this.workflow = workflow;
            this.responder = responder;
        }

        public string Handle(Message message)
        {
            pipeline.Process(message);
            workflow.Start(message);
            return responder.Ok();
        }
    }
}