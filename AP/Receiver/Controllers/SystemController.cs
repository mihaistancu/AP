using AP.Receiver.Handlers;
using AP.Receiver.Responders;

namespace AP.Receiver.Controllers
{
    public class SystemController : Controller
    {
        public SystemController(
            TlsCheckHandler tlsCheck,
            SignatureCheckHandler signatureCheck,
            ValidationHandler validation,
            PersistenceHandler persistence,
            ReceiptAndErrorResponder responder)
            : base(
                  new Pipeline(tlsCheck, signatureCheck, validation, persistence),
                  responder)
        {
        }
    }
}
