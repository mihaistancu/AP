using AP.Processing;
using AP.Receiver.Responders;

namespace AP.Receiver.Channels.Business.Inbound
{
    public class BusinessInboundController : Controller
    {
        public BusinessInboundController(BusinessInboundPipeline pipeline, Workflow workflow, ErrorOnlyResponder responder) : base(pipeline, workflow, responder)
        {
        }
    }
}
