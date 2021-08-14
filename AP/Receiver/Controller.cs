using System;

namespace AP.Receiver
{
    public class Controller
    {
        private Pipeline pipeline;
        private IResponder responder;

        public Controller(Pipeline pipeline, IResponder responder)
        {
            this.pipeline = pipeline;
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
            
            return responder.Receipt();
        }
    }
}