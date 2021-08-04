using AP.Processing;

namespace AP.Receiver
{
    public class Endpoint
    {
        private PipelineFactory pipelineFactory;
        private ResponderFactory responderFactory;
        private Workflow workflow;

        public Endpoint(
            PipelineFactory pipelineFactory, 
            ResponderFactory responderFactory, 
            Workflow workflow)
        {
            this.pipelineFactory = pipelineFactory;
            this.responderFactory = responderFactory;
            this.workflow = workflow;
        }

        public string Handle(Message message)
        {
            var pipeline = pipelineFactory.Create(message.UseCase, message.Channel);
            var responder = responderFactory.Create(message.UseCase);
            var controller = new Controller(pipeline, workflow, responder);
            return controller.Handle(message);
        }
    }
}
