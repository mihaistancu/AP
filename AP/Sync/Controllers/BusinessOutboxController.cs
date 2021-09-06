using AP.Async;
using AP.Sync.Pipelines;
using AP.Sync.Signals;

namespace AP.Sync.Controllers
{
    public class BusinessOutboxController : Controller
    {
        public BusinessOutboxController(
            SignatureCheckPipeline pipeline,
            ErrorOnlySignal responder,
            AsyncProcessor processor)
            : base(pipeline, responder, processor)
        {
        }
    }
}
