using AP.Processing;
using System;

namespace AP.Receiver
{
    public class Controller
    {
        private Pipeline pipeline;
        private IWorkflow workflow;
        private IResponder responder;

        public Controller(Pipeline pipeline, IWorkflow workflow, IResponder responder)
        {
            this.pipeline = pipeline;
            this.workflow = workflow;
            this.responder = responder;
        }

        public string Handle(Message message)
        {
            try
            {
                pipeline.Process(message);
            }
            catch(Exception exception)
            {
                return responder.Error(exception);
            }
            
            workflow.Start(message);
            return responder.Receipt();
        }
    }
}