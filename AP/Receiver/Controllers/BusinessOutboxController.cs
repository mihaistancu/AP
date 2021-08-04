using AP.Processing;
using AP.Receiver.Pipelines;
using AP.Receiver.Responders;

namespace AP.Receiver.Controllers
{
    public class BusinessOutboxController : Controller
    {
        public BusinessOutboxController(BusinessOutboxPipeline pipeline, Workflow workflow, ErrorOnlyResponder responder) : base(pipeline, workflow, responder)
        {
        }
    }
}
