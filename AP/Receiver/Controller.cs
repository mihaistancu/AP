using AP.Processing;
using System;

namespace AP.Receiver
{
    public class Controller
    {
        private Pipeline pipeline;
        private IResponder responder;
        private IAsyncProcessor processor;

        public Controller(Pipeline pipeline, IResponder responder, IAsyncProcessor processor)
        {
            this.pipeline = pipeline;
            this.responder = responder;
            this.processor = processor;
        }

        public string Handle(Message message)
        {
            try
            {
                pipeline.Process(message);
                processor.Process(message);
            }
            catch(Exception exception)
            {
                return responder.Error(exception);
            }
            
            return responder.Receipt();
        }
    }
}