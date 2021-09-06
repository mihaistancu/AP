using AP.Processing;
using AP.Receiver.Pipelines;
using AP.Receiver.Responders;

namespace AP.Receiver.Controllers
{
    public class BusinessInboundController : Controller
    {
        public BusinessInboundController(
            DecryptionPipeline pipeline,
            ErrorOnlyResponder responder,
            AsyncProcessor processor)
            : base(pipeline, responder, processor)
        {
        }
    }
}
