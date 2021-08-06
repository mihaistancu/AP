using AP.Processing;
using AP.Receiver.Handlers;
using AP.Receiver.Responders;

namespace AP.Receiver.Channels.Business.Inbound
{
    public class BusinessInboundController : Controller
    {
        public BusinessInboundController(
            TlsCheckHandler tlsCheck,
            DecryptionHandler decryption,
            ValidationHandler validation,
            PersistenceHandler persistence,
            IWorkflow workflow,
            ErrorOnlyResponder responder)
            : base(
                  new Pipeline(tlsCheck, decryption, validation, persistence),
                  workflow,
                  responder)
        {
        }
    }
}
