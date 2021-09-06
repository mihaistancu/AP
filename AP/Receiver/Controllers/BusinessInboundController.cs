using AP.Processing;
using AP.Receiver.Handlers;
using AP.Receiver.Responders;

namespace AP.Receiver.Controllers
{
    public class BusinessInboundController : Controller
    {
        public BusinessInboundController(IStore store): base(
            new Pipeline(
                store.Get<TlsCheckHandler>(),
                store.Get<DecryptionHandler>(),
                store.Get<ValidationHandler>(),
                store.Get<PersistenceHandler>()),
            store.Get<ErrorOnlyResponder>(),
            store.Get<AsyncProcessor>())
        {
        }
    }
}
