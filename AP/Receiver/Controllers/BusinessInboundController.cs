using AP.Processing;
using AP.Receiver.Pipelines;
using AP.Receiver.Responders;

namespace AP.Receiver.Controllers
{
    public class BusinessInboundController : Controller
    {
        public BusinessInboundController(IStore store): base(
            store.Get<DecryptionPipeline>(),
            store.Get<ErrorOnlyResponder>(),
            store.Get<AsyncProcessor>())
        {
        }
    }
}
