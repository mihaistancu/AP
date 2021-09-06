using AP.Async;
using AP.Sync.Pipelines;
using AP.Sync.Signals;

namespace AP.Sync.Controllers
{
    public class SystemController : Controller
    {
        public SystemController(
            SignatureCheckPipeline syncProcessor,
            AsyncProcessor asyncProcessor,
            ReceiptAndErrorSignal signal)
            : base(syncProcessor, asyncProcessor, signal)
        {
        }
    }
}
