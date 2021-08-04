using AP.Processing;
using AP.Receiver.Responders;

namespace AP.Receiver.Channels.Business.Outbox
{
    public class BusinessOutboxController : Controller
    {
        public BusinessOutboxController(BusinessOutboxPipeline pipeline, Workflow workflow, ErrorOnlyResponder responder) : base(pipeline, workflow, responder)
        {
        }
    }
}
