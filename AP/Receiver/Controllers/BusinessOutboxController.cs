using AP.Processing;
using AP.Receiver.Handlers;
using AP.Receiver.Responders;

namespace AP.Receiver.Controllers
{
    public class BusinessOutboxController : Controller
    {
        public BusinessOutboxController(
            TlsCheckHandler tlsCheck,
            SignatureCheckHandler signatureCheck,
            ValidationHandler validation,
            PersistenceHandler persistence,
            IMessageBroker broker,
            ErrorOnlyResponder responder)
            : base(
                  new Pipeline(tlsCheck, signatureCheck, validation, persistence),
                  broker,
                  responder)
        {
        }
    }
}
