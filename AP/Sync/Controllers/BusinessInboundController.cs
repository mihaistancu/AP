using AP.Async;
using AP.Sync.Pipelines;
using AP.Sync.Signals;

namespace AP.Sync.Controllers
{
    public class BusinessInboundController : Controller
    {
        public BusinessInboundController(
            DecryptionPipeline pipeline,
            ErrorOnlySignal responder,
            AsyncProcessor processor)
            : base(pipeline, responder, processor)
        {
        }
    }
}
