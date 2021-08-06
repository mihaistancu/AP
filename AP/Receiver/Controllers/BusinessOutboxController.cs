using AP.Processing;
using AP.Receiver.Handlers;
using AP.Receiver.Responders;

namespace AP.Receiver.Channels.Business.Outbox
{
    public class BusinessOutboxController : Controller
    {
        public BusinessOutboxController(
            TlsCheckHandler tlsCheck,
            SignatureCheckHandler signatureCheck,
            ValidationHandler validation,
            PersistenceHandler persistence,
            IWorkflow workflow, 
            ErrorOnlyResponder responder) 
            : base(
                  new Pipeline(tlsCheck, signatureCheck, validation, persistence), 
                  workflow, 
                  responder)
        {
        }
    }
}
