using AP.Processing;
using AP.Receiver.Pipelines;
using AP.Receiver.Responders;
using System.Collections.Generic;

namespace AP.Receiver
{
    public class ControllerFactory
    {
        private Workflow workflow;

        public ControllerFactory(Workflow workflow)
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

        public Controller Create(UseCase useCase, Channel channel)
        {
            var pipeline = pipelines[useCase][channel];
            var responder = responders[useCase];
            return new Controller(pipeline, workflow, responder);
        }
    }
}
