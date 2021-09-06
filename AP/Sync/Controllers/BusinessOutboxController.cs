using AP.Async;
using AP.Sync.Pipelines;
using AP.Sync.Signals;

namespace AP.Sync.Controllers
{
    public class BusinessOutboxController : Controller
    {
        public BusinessOutboxController(
            SignatureCheckPipeline syncProcessor,
            AsyncProcessor asyncProcessor,
            ErrorOnlySignal signal)
            : base(syncProcessor, asyncProcessor, signal)
        {
        }
    }
}
