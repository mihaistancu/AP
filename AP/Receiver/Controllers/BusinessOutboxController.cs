using AP.Processing;
using AP.Receiver.Pipelines;
using AP.Receiver.Responders;

namespace AP.Receiver.Controllers
{
    public class BusinessOutboxController : Controller
    {
        public BusinessOutboxController(IStore store): base(
            store.Get<SignatureCheckPipeline>(),
            store.Get<ErrorOnlyResponder>(), 
            store.Get<AsyncProcessor>())
        {
        }
    }
}
