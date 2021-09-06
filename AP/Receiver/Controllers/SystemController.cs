using AP.Processing;
using AP.Receiver.Pipelines;
using AP.Receiver.Responders;

namespace AP.Receiver.Controllers
{
    public class SystemController : Controller
    {
        public SystemController(IStore store): base(
            store.Get<SignatureCheckPipeline>(),
            store.Get<ReceiptAndErrorResponder>(),
            store.Get<AsyncProcessor>())
        {
        }
    }
}
