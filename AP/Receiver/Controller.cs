using AP.Processing;
using System;

namespace AP.Receiver
{
    public class Controller
    {
        private Pipeline pipeline;
        private IResponder responder;
        private IWorkflowFactory factory;

        public Controller(Pipeline pipeline, IResponder responder, IWorkflowFactory factory)
        {
            this.pipeline = pipeline;
            this.responder = responder;
            this.factory = factory;
        }

        public string Handle(Message message)
        {
            try
            {
                pipeline.Process(message);
                var workflow = factory.Get(message.SedType);
                workflow.Start(message);
            }
            catch(Exception exception)
            {
                return responder.Error(exception);
            }
            
            return responder.Receipt();
        }
    }
}