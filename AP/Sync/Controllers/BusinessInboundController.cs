using AP.Async;
using AP.Sync.Pipelines;
using AP.Sync.Signals;

namespace AP.Sync.Controllers
{
    public class BusinessInboundController : Controller
    {
        public BusinessInboundController(
            DecryptionPipeline syncProcessor,
            AsyncProcessor asyncProcessor, 
            ErrorOnlySignal signal)
            : base(syncProcessor, asyncProcessor, signal)
        {
        }
    }
}
