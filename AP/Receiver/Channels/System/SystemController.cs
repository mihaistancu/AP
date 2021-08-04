using AP.Processing;
using AP.Receiver.Responders;

namespace AP.Receiver.Channels.System
{
    public class SystemController : Controller
    {
        public SystemController(SystemPipeline pipeline, Workflow workflow, ReceiptAndErrorResponder responder) : base(pipeline, workflow, responder)
        {
        }
    }
}
