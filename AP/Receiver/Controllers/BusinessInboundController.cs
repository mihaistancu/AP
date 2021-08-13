using AP.Processing;
using AP.Receiver.Handlers;
using AP.Receiver.Responders;

namespace AP.Receiver.Controllers
{
    public class BusinessInboundController : Controller
    {
        public BusinessInboundController(
            TlsCheckHandler tlsCheck,
            DecryptionHandler decryption,
            ValidationHandler validation,
            PersistenceHandler persistence,
            IMessageBroker broker,
            ErrorOnlyResponder responder)
            : base(
                  new Pipeline(tlsCheck, decryption, validation, persistence),
                  broker,
                  responder)
        {
        }
    }
}
