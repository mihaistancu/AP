using AP.Processing;
using AP.Receiver.Pipelines;
using AP.Receiver.Responders;

namespace AP.Receiver.Controllers
{
    public class SystemController : Controller
    {
        public SystemController(SystemPipeline pipeline, Workflow workflow, ReceiptAndErrorResponder responder) : base(pipeline, workflow, responder)
        {
        }
    }
}
