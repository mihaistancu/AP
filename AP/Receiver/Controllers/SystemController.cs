using AP.Processing;
using AP.Receiver.Handlers;
using AP.Receiver.Responders;

namespace AP.Receiver.Channels.System
{
    public class SystemController : Controller
    {
        public SystemController(
            TlsCheckHandler tlsCheck,
            SignatureCheckHandler signatureCheck,
            ValidationHandler validation,
            PersistenceHandler persistence,
            IWorkflow workflow, 
            ReceiptAndErrorResponder responder) 
            : base(
                  new Pipeline(tlsCheck, signatureCheck, validation, persistence), 
                  workflow, 
                  responder)
        {
        }
    }
}
