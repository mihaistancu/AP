using AP.Processing;
using AP.Receiver.Pipelines;
using AP.Receiver.Responders;
using System.Collections.Generic;

namespace AP.Receiver
{
    public class Router
    {
        private Workflow workflow;

        public Router(Workflow workflow)
        {
            this.workflow = workflow;
        }

        private Dictionary<UseCase, Dictionary<Channel, Pipeline>> pipelines =
            new Dictionary<UseCase, Dictionary<Channel, Pipeline>>
            {
                {
                    UseCase.Business,
                    new Dictionary<Channel, Pipeline>()
                    {
                        { Channel.Inbound, new BusinessInboundPipeline() }
                    }
                }
            };

        private Dictionary<UseCase, IResponder> responders = 
            new Dictionary<UseCase, IResponder>
            {
                { UseCase.Business, new ReceiptAndErrorResponder() },
                { UseCase.System, new ErrorOnlyResponder() },
            };

        public void Route(Message message)
        {
            var pipeline = pipelines[message.UseCase][message.Channel];
            var responder = responders[message.UseCase];
            var controller = new Controller(pipeline, workflow, responder);
            controller.Handle(message);
        }
    }
}
