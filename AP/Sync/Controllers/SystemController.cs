using AP.Async;
using AP.Sync.Pipelines;
using AP.Sync.Signals;

namespace AP.Sync.Controllers
{
    public class SystemController : Controller
    {
        public SystemController(
            SignatureCheckPipeline pipeline,
            ReceiptAndErrorSignal responder,
            AsyncProcessor processor)
            : base(pipeline, responder, processor)
        {
        }
    }
}
