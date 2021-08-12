using AP.Processing;
using System;

namespace AP.Receiver
{
    public class Controller
    {
        private Pipeline pipeline;
        private IMessageBroker broker;
        private IResponder responder;

        public Controller(Pipeline pipeline, IMessageBroker broker, IResponder responder)
        {
            this.pipeline = pipeline;
            this.broker = broker;
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
            
            broker.Send(message);
            return responder.Receipt();
        }
    }
}