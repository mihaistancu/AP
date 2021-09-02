using AP.Processing;
using AP.Receiver.Handlers;
using AP.Receiver.Responders;

namespace AP.Receiver.Controllers
{
    public class BusinessOutboxController : Controller
    {
        public BusinessOutboxController(IStore store): base(
            new Pipeline(
                store.Get<TlsCheckHandler>(),
                store.Get<SignatureCheckHandler>(),
                store.Get<ValidationHandler>(),
                store.Get<PersistenceHandler>()),
            store.Get<ErrorOnlyResponder>(), 
            store.Get<WorkflowFactory>())
        {
        }
    }
}
